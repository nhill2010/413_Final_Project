using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Scene_0Waves : _Scene_Waves
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
        pathCoors.Add(new Vector3(-WIDTH_BOUND * 1.1f, 0, 0)); // start at left
        pathCoors.Add(new Vector3(0, HEIGHT_BOUND * .8f, 0));
        pathCoors.Add(new Vector3(0, -HEIGHT_BOUND * .8f, 0));
        pathCoors.Add(new Vector3(WIDTH_BOUND * 1.1f, 0, 0)); // end at right

        // create a path from the coordinates
        GameObject pathGO = Instantiate(pathPrefab);
        Path myPath = pathGO.GetComponent<Path>();
        myPath.Initialize(pathCoors, PATH_WIDTH, PATH_BORDER_WIDTH);

        return myPath;
    }
}
