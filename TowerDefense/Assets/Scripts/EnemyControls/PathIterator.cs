using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathIterator
{
    private Path path;
    public Vector3 currentCoorPos;
    public int targetIndex;
    public float speed;

    // constructor for PathIterator
    public PathIterator(Path pathPar, float speedPar)
    {
        // set initial parameters, start at first element
        speed = speedPar;
        path = pathPar;
        targetIndex = 0;
        currentCoorPos = path.Head();
    }

    // create copy of PathIterator
    public PathIterator(PathIterator iterPar)
    {
        // set values to parameter
        speed = iterPar.speed;
        targetIndex = iterPar.targetIndex;
        currentCoorPos = iterPar.currentCoorPos;
        path = iterPar.path;
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

    // comparison operator for PathIterator:
    // first, compares how many coordinates were passed
    // if equal coordinates passed, returns Iterator with
    //    less distance to the next cooordinate
    // do no use if paths are not symmetrical
    public static bool operator>(PathIterator one, PathIterator other)
    {
        // if at end, return if one reached end first
        if( one.End() || other.End() )
        {
            return one.End() && !other.End();
        }
        // return if one's index > other's index
        if( one.targetIndex != other.targetIndex )
        {
            return one.targetIndex > other.targetIndex;
        }
        Vector3 oneTarget, otherTarget;
        oneTarget = one.path[one.targetIndex];
        otherTarget = other.path[other.targetIndex];
        float oneDistance, otherDistance;
        // distance between target and current position
        oneDistance = (oneTarget - one.currentCoorPos).magnitude;
        otherDistance = (otherTarget - other.currentCoorPos).magnitude;
        return oneDistance < otherDistance;
    }

    // see > operator
    public static bool operator<(PathIterator one, PathIterator other)
    {
        return other > one;
    }

    // iterate multiple times (negative iterations will be treated as 0)
    public static PathIterator operator+(PathIterator iter, int iterations)
    {
        // create a copy of the iterator
        PathIterator result = new PathIterator(iter);

        // iterate for each iteration
        for( int iteration = 0; iteration < iterations; iteration++ )
        {
            result++;
        }
        return result;
    }
}
