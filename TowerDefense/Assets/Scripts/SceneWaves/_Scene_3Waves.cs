using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Scene_3Waves : _Scene_Waves
{
    protected override List<Path> InitializePaths()
    {
        List<Path> paths = new List<Path>();
        paths.Add(createPath1());
        paths.Add(createPath2());
        return paths;
    }

    private Path createPath1()
    {
        // create coordinates for enemies to follow
        List<Vector3> pathCoors = new List<Vector3>();

        pathCoors.Add(new Vector3(-WIDTH_BOUND * 1.5f, -HEIGHT_BOUND, 0));
        pathCoors.Add(new Vector3(0, -HEIGHT_BOUND, 0));
        pathCoors.Add(new Vector3(0, HEIGHT_BOUND, 0));
        pathCoors.Add(new Vector3(-WIDTH_BOUND / 2, HEIGHT_BOUND / 2, 0));
        pathCoors.Add(new Vector3(-WIDTH_BOUND, HEIGHT_BOUND, 0));

        // create a path from the coordinates
        GameObject pathGO = Instantiate(pathPrefab);
        Path pathObj = pathGO.GetComponent<Path>();
        pathObj.Initialize(pathCoors, PATH_WIDTH, PATH_BORDER_WIDTH);

        return pathObj;
    }

    private Path createPath2()
    {
        // create coordinates for enemies to follow
        List<Vector3> pathCoors = new List<Vector3>();

        pathCoors.Add(new Vector3(WIDTH_BOUND, HEIGHT_BOUND * 1.5f, 0));
        pathCoors.Add(new Vector3(WIDTH_BOUND, 0, 0));
        pathCoors.Add(new Vector3(-WIDTH_BOUND, 0, 0));
        pathCoors.Add(new Vector3(-WIDTH_BOUND / 2, HEIGHT_BOUND / 2, 0));
        pathCoors.Add(new Vector3(-WIDTH_BOUND, HEIGHT_BOUND, 0));

        // create a path from the coordinates
        GameObject pathGO = Instantiate(pathPrefab);
        Path pathObj = pathGO.GetComponent<Path>();
        pathObj.Initialize(pathCoors, PATH_WIDTH, PATH_BORDER_WIDTH);

        return pathObj;
    }
}
