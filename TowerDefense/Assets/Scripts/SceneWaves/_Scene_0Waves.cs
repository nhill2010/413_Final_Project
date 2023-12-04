using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWave : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject wavePrefab;
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public GameObject pathPrefab;
    public static float HEIGHT_BOUND = 8f;
    public static float WIDTH_BOUND = 18f;
    private float spawnDelay = .4f;
    int numEnemies = 15;
    private static float PATH_WIDTH = HEIGHT_BOUND / 3.0f;
    private static float PATH_BORDER_WIDTH = PATH_WIDTH / 10.0f;
    private static float ENEMY_DIAMETER = PATH_WIDTH * 0.4f;

    private Path path1;

    private void Start()
    {
        path1 = createPath1();
    }

    public void RunEnemies()
    {
        createAndRunWave(path1);
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
