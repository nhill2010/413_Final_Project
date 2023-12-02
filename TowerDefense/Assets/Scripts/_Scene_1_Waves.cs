using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Scene_1_Waves : MonoBehaviour
{

    [Header("Inscribed")]
    public GameObject wavePrefab;
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public GameObject pathPrefab;
    public static float HEIGHT_BOUND = 6.5f;
    public static float WIDTH_BOUND = 14f;
    private float spawnDelay = 1.0f;
    float speed = .1f;
    int numEnemies = 10;
    private static float PATH_WIDTH = HEIGHT_BOUND / 3.0f;
    private static float PATH_BORDER_WIDTH = PATH_WIDTH / 10.0f;
    private static float ENEMY_DIAMETER = PATH_WIDTH * 0.4f;

    private Path path1;
    private Path path2;


    // Start is called before the first frame update
    private void Start()
    {
        path1 = createPath1();
        path2 = createPath2();
    }

    public void RunEnemies()
    {
        createAndRunWave(path1);
        createAndRunWave(path2);
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


    private void createAndRunWave( Path path )
    {
        // create a wave
        Wave wave = null;
        wave = Instantiate(wavePrefab).GetComponent<Wave>();
        wave.SetPath(path);

        // add enemies to the wave
        wave.addEnemiesToWave(createEnemyStat(), createSpawnData());
        wave.addEnemiesToWave(createEnemy2Stat(), createSpawnData2());

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

    // enemy with standard speed and first prefab
    private EnemyStats createEnemyStat()
    {
        EnemyStats enemyStat = new EnemyStats();
        enemyStat.health = 2;
        enemyStat.damageToColony = .1f;
        enemyStat.enemyCashValue = 100;
        enemyStat.speed = speed;
        return enemyStat;
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

    // enemy with extra speed and second prefab
    private EnemyStats createEnemy2Stat()
    {
        EnemyStats enemyStat = new EnemyStats();
        enemyStat.health = 6;
        enemyStat.damageToColony = .2f;
        enemyStat.enemyCashValue = 300;
        enemyStat.speed = speed * 1.5f;
        return enemyStat;
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
