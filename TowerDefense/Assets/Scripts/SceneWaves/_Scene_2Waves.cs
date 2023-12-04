using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Scene_2Waves : MonoBehaviour
{

    [Header("Inscribed")]
    public GameObject wavePrefab;
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public GameObject pathPrefab;
    public static float HEIGHT_BOUND = 6.5f;
    public static float WIDTH_BOUND = 14f;
    private float spawnDelay = .5f;
    int numEnemies = 10;
    private static float PATH_WIDTH = HEIGHT_BOUND / 3.0f;
    private static float PATH_BORDER_WIDTH = PATH_WIDTH / 10.0f;
    private static float ENEMY_DIAMETER = PATH_WIDTH * 0.4f;

    private Path path1;


    // Start is called before the first frame update
    private void Start()
    {
        UIManagement.S.waveCurrent = 0;
        path1 = createPath1();
    }

    public void RunEnemies()
    {
        // check wave limit not met
        if (UIManagement.S.waveCurrent < UIManagement.S.waveTotal)
        {
            // increment the wave count, create and run waves
            UIManagement.S.waveCurrent++;
            createAndRunWave(path1);
        }
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


    private void createAndRunWave(Path path)
    {
        // create a wave
        Wave wave = null;
        wave = Instantiate(wavePrefab).GetComponent<Wave>();
        wave.SetPath(path);

        // add enemies to the wave
        wave.addEnemiesToWave(createSpawnData());
        wave.addEnemiesToWave(createSpawnData2());

        wave.run();
    }

    // create coordinates that form a circle
    // start/endPercent determine what percentage of the circle the coordinates
    //     start and end at
    List<Vector3> GenerateCircleCoors(float radiusX, float radiusY,
                                      Vector3 center,
                                      float startPercent,
                                      float endPercent)
    {
        List<Vector3> coors = new List<Vector3>();
        float precision = .1f;
        float startAngle = Mathf.PI * 2 * startPercent;
        float endAngle = Mathf.PI * 2 * endPercent;
        for (float angle = startAngle; angle < endAngle; angle += precision)
        {
            Vector3 coor = new Vector3();
            coor.x = center.x + Mathf.Sin(angle) * radiusX;
            coor.y = center.y + Mathf.Cos(angle) * radiusY;
            coor.z = 0;
            coors.Add(coor);
        }
        return coors;
    }

    private SpawnData createSpawnData()
    {
        SpawnData spawnData = new SpawnData();
        spawnData.enemyDiameter = ENEMY_DIAMETER;
        spawnData.enemyPrefab = enemyPrefab;
        spawnData.numEnemies = numEnemies;
        spawnData.delay = spawnDelay;
        return spawnData;
    }

    private SpawnData createSpawnData2()
    {
        SpawnData spawnData = new SpawnData();
        spawnData.enemyDiameter = ENEMY_DIAMETER;
        spawnData.enemyPrefab = enemyPrefab2;
        spawnData.numEnemies = numEnemies;
        spawnData.delay = spawnDelay * 2;
        return spawnData;
    }
}
