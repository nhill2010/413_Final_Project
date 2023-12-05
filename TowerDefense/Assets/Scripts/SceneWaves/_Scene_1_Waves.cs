using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Scene_1_Waves : _Scene_Waves
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
        Vector3 circleCenter = Vector3.zero;
        float circleRadius = HEIGHT_BOUND * .5f;

        // create coordinates for enemies to follow
        List<Vector3> pathCoors = new List<Vector3>();

        pathCoors.Add(new Vector3(-WIDTH_BOUND * 1.5f, -HEIGHT_BOUND, 0));

        circleCenter.x = WIDTH_BOUND - circleRadius;
        circleCenter.y = -HEIGHT_BOUND + circleRadius;
        pathCoors.AddRange(GenerateCircleCoors(circleRadius, -circleRadius,
                                               circleCenter, 0f, 1.25f));

        pathCoors.Add(new Vector3(WIDTH_BOUND, HEIGHT_BOUND, 0));

        circleCenter.x = -WIDTH_BOUND + circleRadius;
        circleCenter.y = HEIGHT_BOUND - circleRadius;
        pathCoors.AddRange(GenerateCircleCoors(-circleRadius, circleRadius,
                                               circleCenter, 0f, 1.625f));

        pathCoors.Add(Vector3.zero);

        // create a path from the coordinates
        GameObject pathGO = Instantiate(pathPrefab);
        Path pathObj = pathGO.GetComponent<Path>();
        pathObj.Initialize(pathCoors, PATH_WIDTH, PATH_BORDER_WIDTH);

        return pathObj;
    }

    private Path createPath2()
    {
        Vector3 circleCenter = Vector3.zero;
        float circleRadius = HEIGHT_BOUND * .5f;

        // create coordinates for enemies to follow
        List<Vector3> pathCoors = new List<Vector3>();

        pathCoors.Add(new Vector3(WIDTH_BOUND * 1.5f, HEIGHT_BOUND, 0));

        circleCenter.x = -WIDTH_BOUND + circleRadius;
        circleCenter.y = HEIGHT_BOUND - circleRadius;
        pathCoors.AddRange(GenerateCircleCoors(-circleRadius, circleRadius,
                                               circleCenter, 0f, 1.25f));

        pathCoors.Add(new Vector3(-WIDTH_BOUND, -HEIGHT_BOUND, 0));

        circleCenter.x = WIDTH_BOUND - circleRadius;
        circleCenter.y = -HEIGHT_BOUND + circleRadius;
        pathCoors.AddRange(GenerateCircleCoors(circleRadius, -circleRadius,
                                               circleCenter, 0f, 1.625f));

        pathCoors.Add(Vector3.zero);

        // create a path from the coordinates
        GameObject pathGO = Instantiate(pathPrefab);
        Path pathObj = pathGO.GetComponent<Path>();
        pathObj.Initialize(pathCoors, PATH_WIDTH, PATH_BORDER_WIDTH);

        return pathObj;
    }
}
