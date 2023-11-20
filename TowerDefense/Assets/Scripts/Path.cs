using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public List<Vector3> coordinates;
    public GameObject outlineCube;
    public GameObject backgroundCube;
    public GameObject outlineCylinder;
    public GameObject backgroundCylinder;

    // constructor for Path: must be called before using other methods
    public void Initialize(List<Vector3> pathCoors, float pathLength, float outlineLength)
    {
        coordinates = pathCoors;
        CreatePhysicalPath(pathLength, outlineLength);
    }

    public Vector3 Head()
    {
        return coordinates[0];
    }

    public Vector3 Tail()
    {
        return coordinates[coordinates.Count - 1];
    }

    public bool End(int targetIndex)
    {
        return targetIndex >= coordinates.Count;
    }

    public Vector3 GetNextPosition(ref int targetIndex,
                                    Vector3 currentCoor,
                                    float distance)
    {
        // at end of path: return last coordinate on path
        if (targetIndex >= coordinates.Count)
        {
            return this.Tail();
        }

        // get coordinates from target
        Vector3 targetCoor = coordinates[targetIndex];

        // calculate distance from current to target
        float currentToTarget = (targetCoor - currentCoor).magnitude;

        // case 1: unable to reach next target
        if (distance < currentToTarget)
        {
            /* Vectors will point from the target to the current position */
            // create direction vector
            Vector3 directionVector = currentCoor - targetCoor;
            directionVector.Normalize();

            // update currentToTarget distance
            currentToTarget -= distance;

            // return scaled direction vector from target
            return targetCoor + directionVector * currentToTarget;
        }

        // case 2: enough distance to get pass target
        // remove distance traveled from current to target
        distance -= currentToTarget;

        // set current coordinate to the target
        currentCoor = targetCoor;

        // select the next target
        targetIndex++;

        // return the position from updated values
        return this.GetNextPosition(ref targetIndex, currentCoor, distance);
    }

    public PathIterator Begin(float speed)
    {
        return new PathIterator(this, speed);
    }


    // create physical path for Path
    /*
     * Creates a circle at each coordinate, and rectangle between each circle. 
     * Background circles/rectangles will create space inside the path
     *   to create an outline
     */
    private void CreatePhysicalPath( float pathLength, float outlineLength )
    {
        Vector3 currentCoor, nextCoor;
        Vector3 outlineScale, backgroundScale;
        int coorInd;

        // rectangle section
        for( coorInd = 0; coorInd + 1 < coordinates.Count; coorInd++ )
        {
            GameObject outlineRectGO = Instantiate(outlineCube, this.transform);
            GameObject backgroundRectGO = Instantiate(backgroundCube, this.transform);
            currentCoor = coordinates[coorInd];
            nextCoor = coordinates[coorInd + 1];

            outlineRectGO.transform.position = (currentCoor + nextCoor) * 0.5f;
            backgroundRectGO.transform.position = (currentCoor + nextCoor) * 0.5f;

            outlineScale.x = (currentCoor - nextCoor).magnitude;
            outlineScale.y = pathLength;
            outlineScale.z = .001f;

            backgroundScale.x = outlineScale.x;
            backgroundScale.y = outlineScale.y - outlineLength;
            backgroundScale.z = .002f;

            outlineRectGO.transform.localScale = outlineScale;
            backgroundRectGO.transform.localScale = backgroundScale;

            // positive z rotation rotates counter clock wise (in degrees)
            // tan(angle) = dy / dx
            Vector3 rotation = Vector3.zero;
            rotation.z = Mathf.Rad2Deg * Mathf.Atan((nextCoor.y - currentCoor.y) / (nextCoor.x - currentCoor.x));
            outlineRectGO.transform.eulerAngles = rotation;
            backgroundRectGO.transform.eulerAngles = rotation;
        }


        // cylinder section
        // set cylinder scales for background and outline
        outlineScale.x = pathLength;
        outlineScale.z = pathLength;
        backgroundScale.x = pathLength - outlineLength;
        backgroundScale.z = pathLength - outlineLength;
        // make the y scale flat
        backgroundScale.y = .002f;
        outlineScale.y = .001f;
        for ( coorInd = 0; coorInd < coordinates.Count; coorInd++ )
        {
            // create a cylinder at each coordinate
            GameObject outlineCircleGO = Instantiate(outlineCylinder, this.transform);
            GameObject backgroundCircleGO = Instantiate(backgroundCylinder, this.transform);
            currentCoor = coordinates[coorInd];
            outlineCircleGO.transform.position = currentCoor;
            backgroundCircleGO.transform.position = currentCoor;
            outlineCircleGO.transform.localScale = outlineScale;
            backgroundCircleGO.transform.localScale = backgroundScale;
        }
    }
}
