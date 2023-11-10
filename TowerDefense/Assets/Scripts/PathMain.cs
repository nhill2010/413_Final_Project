using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMain : MonoBehaviour
{
    static bool testGameObjectOnPath = true;
    PathIterator pathIter;
    float speed = .1f;

    // Start is called before the first frame update
    void Start()
    {
        //this.testPathGeneration();
        //this.testPathIteration();
        //this.testForLoopIteration();

        if( testGameObjectOnPath )
        {
            // create list of coordinates for the path
            List<Vector3> pathCoors = new List<Vector3>
            {
                new Vector3(0, 0, 0),
                new Vector3(5, 5, 0),
                new Vector3(10, 5, 0 ),
                new Vector3(5, 10, 0 ),
                new Vector3(0, 0, 0 )
            };
            // after moved to the other points, move in a circle
            pathCoors.AddRange(GenerateCircleCoors(5, Vector3.zero));

            // create a path object from the list of coordinates
            Path gameObjectPath = new Path(pathCoors);

            // create an iterator for the path using this' speed, 
            // update this' position to match the pathIter
            pathIter = gameObjectPath.Begin(speed);
            transform.position = pathIter.pos();
        }
    }

    void FixedUpdate()
    {
        if (testGameObjectOnPath)
        {
            // if the iterator has not ended, 
            // increment the iterator, 
            // and update this' position to match the pathIter
            if (!pathIter.End())
            {
                Debug.Log(transform.position);
                pathIter++;
                transform.position = pathIter.pos();
            }
            // otherwise, iterator has ended:
            //   destroy the gameObject
            else
            {
                Debug.Log("Completed path: Destroy GameObject");
                Destroy(gameObject);
            }
        }
    }

    // creates coordinates that form a circle
    List<Vector3> GenerateCircleCoors(int radius, Vector3 center)
    {
        List<Vector3> coors = new List<Vector3>();
        for (float angle = 0; angle < 2 * Mathf.PI; angle += .1f)
        {
            Vector3 coor;
            coor.x = center.x + Mathf.Sin(angle) * radius;
            coor.y = center.y + Mathf.Cos(angle) * radius;
            coor.z = 0;
            coors.Add(coor);
        }
        return coors;
    }

    ///////////////////////// generic testing //////////////////////
    void testPathGeneration()
    {
        Debug.Log("Testing Path Generation");
        List<Vector3> pathCoors = new List<Vector3>();
        pathCoors.Add(new Vector3(0, 0, 0));
        pathCoors.Add(new Vector3(1, 1, 0));
        Path myPath = new Path(pathCoors);
        Debug.Log("Done Testing Path Generation");
    }

    void testPathIteration()
    {
        Debug.Log("Testing Path Iteration");
        List<Vector3> pathCoors = new List<Vector3>();
        pathCoors.Add(new Vector3(0, 0, 0));
        pathCoors.Add(new Vector3(50, 50, 0));
        pathCoors.Add(new Vector3(100, 50, 0));
        pathCoors.Add(new Vector3(50, 100, 0));
        pathCoors.Add(new Vector3(0, 0, 0));
        Path myPath = new Path(pathCoors);

        PathIterator myIter = new PathIterator(myPath,10);

        string myStr = "";
        while( !myIter.End() )
        {
            myIter++;
            myStr += myIter.pos().ToString() + "\n";
        }
        Debug.Log(myStr);
        Debug.Log("Done Testing Path Iteration");
    }

    void testForLoopIteration()
    {
        List<Vector3> pathCoors = new List<Vector3> 
        {
            new Vector3(0, 0, 0), 
            new Vector3(50, 50, 0), 
            new Vector3(100, 50, 0 ), 
            new Vector3(50, 100, 0 ), 
            new Vector3(0, 0, 0 )
        };

        Path path = new Path(pathCoors);
        int speed = 10;

        for (PathIterator pathIter = path.Begin(speed); !pathIter.End(); pathIter++)
        {
            Debug.Log(pathIter.pos());
        }
    }
    /////////////////////////// generic testing end ///////////////////////////
}


