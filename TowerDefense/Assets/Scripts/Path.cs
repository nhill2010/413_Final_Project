using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path
{
    public List<Vector3> coordinates;

    // constructor for Path: must be called before using other methods
    public Path(List<Vector3> pathCoors)
    {
        coordinates = pathCoors;
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
}
