using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTester : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject wavePrefab;
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    float speed = .4f;
    int numEnemies = 10;

    // Start is called before the first frame update
    void Start()
    {
        // create coordinates for enemies to follow
        List<Vector3> pathCoors = new List<Vector3>();
        pathCoors.Add(new Vector3(125, 0, 0)); // start at right
        pathCoors.AddRange(GenerateCircleCoors( 80, 50, Vector3.zero, .25f, 1.125f));
        pathCoors.AddRange(GenerateCircleCoors(-40, 25, Vector3.zero, -.125f, 0.5f));
        pathCoors.Add(Vector3.zero); // end at middle
        //pathCoors.Reverse(); // reverse coordinates

        // create a path from the coordinates
        Path myPath = new Path(pathCoors);

        // create a wave
        GameObject myWave = Instantiate(wavePrefab);
        myWave.GetComponent<Wave>().SetPath(myPath);

        // add enemies to the wave (EnemyStats,numEnemies,spawnDelay)
        myWave.GetComponent<Wave>().addEnemiesToWave(createEnemyStat(), numEnemies, 2.0f);
        myWave.GetComponent<Wave>().addEnemiesToWave(createEnemy2Stat(), numEnemies,1.0f);

        // run the wave once
        myWave.GetComponent<Wave>().run();
    }

    // enemy with standard speed and first prefab
    private EnemyStats createEnemyStat()
    {
        EnemyStats enemyStat = new EnemyStats();
        enemyStat.testVal = 0;
        enemyStat.speed = speed;
        enemyStat.prefab = enemyPrefab;
        return enemyStat;
    }

    // enemy with extra speed and second prefab
    private EnemyStats createEnemy2Stat()
    {
        EnemyStats enemyStat = new EnemyStats();
        enemyStat.testVal = 1;
        enemyStat.speed = speed * 3;
        enemyStat.prefab = enemyPrefab2;
        return enemyStat;
    }

    // create coordinates that form a circle
    // start/endPercent determine what percentage of the circle the coordinates
    //     start and end at
    List<Vector3> GenerateCircleCoors(int radiusX, int radiusY, 
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
}
