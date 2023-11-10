using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathIterator
{
    private Path path;
    private Vector3 currentCoorPos;
    private int targetIndex;
    private float speed;

    // constructor for PathIterator
    public PathIterator(Path pathPar, float speedPar)
    {
        // set initial parameters, start at first element
        speed = speedPar;
        path = pathPar;
        targetIndex = 0;
        currentCoorPos = path.Head();
    }

    public Vector3 pos()
    {
        return currentCoorPos;
    }

    public bool End()
    {
        return path.End(targetIndex);
    }

    public static PathIterator operator++(PathIterator iter)
    {
        // advance the position using speed as the distance to move
        iter.currentCoorPos = iter.path.GetNextPosition(ref iter.targetIndex, 
                                                        iter.currentCoorPos, 
                                                        iter.speed);
        return iter;
    }
}
