using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Scene_3Waves : MonoBehaviour
{

    [Header("Inscribed")]
    public GameObject wavePrefab;
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public GameObject pathPrefab;
    public static float HEIGHT_BOUND = 6.5f;
    public static float WIDTH_BOUND = 14f;
    private float spawnDelay = 1.0f;
    int numEnemies = 10;
    private static float PATH_WIDTH = HEIGHT_BOUND / 3.0f;
    private static float PATH_BORDER_WIDTH = PATH_WIDTH / 10.0f;
    private static float ENEMY_DIAMETER = PATH_WIDTH * 0.4f;

    private Path path1;
    private Path path2;


    // Start is called before the first frame update
    private void Start()
    {
        UIManagement.S.waveCurrent = 0;
        path1 = createPath1();
        path2 = createPath2();
    }

    private void Update()
    {
        if (Enemy.ENEMY_COUNT == 0 && UIManagement.S.waveCurrent >= UIManagement.S.waveTotal && Wave.WAVE_COUNT == 0)
        {
            UIManagement.S.OnWavesEnd();
            Destroy(this);
        }
    }

    public void RunEnemies()
    {
        // check wave limit not met
        if (UIManagement.S.waveCurrent < UIManagement.S.waveTotal)
        {
            // increment the wave count, create and run waves
            UIManagement.S.waveCurrent++;
            createAndRunWave(path1);
            createAndRunWave(path2);
        }
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
