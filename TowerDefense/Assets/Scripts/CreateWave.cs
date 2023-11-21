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
    private float waveDelay = 3f;
    float speed = .1f;
    int numEnemies = 10;
    Wave wave = null;
    private static float PATH_WIDTH = HEIGHT_BOUND / 3.0f;
    private static float PATH_BORDER_WIDTH = PATH_WIDTH / 10.0f;
    private static float ENEMY_DIAMETER = PATH_WIDTH * 0.4f;


    // Start is called before the first frame update
    void Start()
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
        myPath.Initialize(pathCoors, PATH_WIDTH, PATH_BORDER_WIDTH );

        // create a wave
        wave = Instantiate(wavePrefab).GetComponent<Wave>();
        wave.SetPath(myPath);

        // add enemies to the wave (EnemyStats,numEnemies,spawnDelay)
        wave.addEnemiesToWave(createEnemyStat(), numEnemies, 2.0f);
        wave.addEnemiesToWave(createEnemy2Stat(), numEnemies, 1.0f);

        // run the wave once
        Invoke("RunWave", waveDelay);
    }

    void RunWave()
    {
        if (wave != null)
        {
            wave.run();
        }
    }

    // enemy with standard speed and first prefab
    private EnemyStats createEnemyStat()
    {
        EnemyStats enemyStat = new EnemyStats();
        enemyStat.diameter = ENEMY_DIAMETER;
        enemyStat.health = 1;
        enemyStat.damageToColony = 1;
        enemyStat.enemyCashValue = 100;
        enemyStat.speed = speed;
        enemyStat.prefab = enemyPrefab;
        return enemyStat;
    }

    // enemy with extra speed and second prefab
    private EnemyStats createEnemy2Stat()
    {
        EnemyStats enemyStat = new EnemyStats();
        enemyStat.diameter = ENEMY_DIAMETER;
        enemyStat.health = 3;
        enemyStat.damageToColony = 2;
        enemyStat.enemyCashValue = 300;
        enemyStat.speed = speed * 3;
        enemyStat.prefab = enemyPrefab2;
        return enemyStat;
    }

}
