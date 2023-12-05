using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Scene_2Waves : _Scene_Waves
{
    protected override List<Path> InitializePaths()
    {
        List<Path> paths = new List<Path>();
        paths.Add(createPath1());
        return paths;
    }

    private Path createPath1()
    {
        // create coordinates for enemies to follow
        List<Vector3> pathCoors = new List<Vector3>();
        pathCoors.Add(new Vector3(HEIGHT_BOUND * 1.5f, 0, 0)); // start at right
        pathCoors.AddRange(GenerateCircleCoors(WIDTH_BOUND, HEIGHT_BOUND, Vector3.zero, .25f, 1.125f));
        pathCoors.AddRange(GenerateCircleCoors(-WIDTH_BOUND/2, HEIGHT_BOUND/2, Vector3.zero, -.125f, 0.5f));
        pathCoors.Add(Vector3.zero); // end at middle
        //pathCoors.Reverse(); // reverse coordinates

        // create a path from the coordinates
        GameObject pathGO = Instantiate(pathPrefab);
        Path myPath = pathGO.GetComponent<Path>();
        myPath.Initialize(pathCoors, PATH_WIDTH, PATH_BORDER_WIDTH);

        return myPath;
    }
}
