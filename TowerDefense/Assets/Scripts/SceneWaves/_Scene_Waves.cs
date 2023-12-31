using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


/*
 * Functions to override: 
 *    InitializePaths (recommended)
 *    InitializeWaves (optional)
 */
public class _Scene_Waves : MonoBehaviour
{
    // prefabs
    [Header("Inscribed")]
    public GameObject wavePrefab;
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public GameObject enemyPrefab4;
    public GameObject enemyPrefab42;
    public GameObject pathPrefab;
    

    // size values
    public static float HEIGHT_BOUND = 6.5f;
    public static float WIDTH_BOUND = 14f;
    public static float PATH_WIDTH = HEIGHT_BOUND / 3.0f;
    public static float PATH_BORDER_WIDTH = PATH_WIDTH / 10.0f;
    public static float ENEMY_DIAMETER = PATH_WIDTH * 0.4f;

    private List<Path> _paths = new List<Path>();
    private List<List<Wave>> _waves = new List<List<Wave>>();
    private int startWave = 1;


    // Start is called before the first frame update
    void Start()
    {
        UIManagement.S.waveCurrent = startWave - 1;
        _paths = InitializePaths();
        _waves = new List<List<Wave>>();
        foreach (Path path in _paths)
        {
            _waves.Add(InitializeWaves(path));
        }
        UIManagement.S.waveTotal = _waves[0].Count;
    }

    private void Update()
    {
        // Error where OnWavesEnd() is not called at end
        //     Results: unable to reproduce so far
        /*
        Debug.Log("----------------------");
        Debug.Log(Enemy.ENEMY_COUNT); // expect 0
        Debug.Log(UIManagement.S.waveCurrent); // expect 10
        Debug.Log(UIManagement.S.waveTotal); // expect 10
        Debug.Log(Wave.WAVE_COUNT); // expect 0
        */

        if (Enemy.ENEMY_COUNT == 0 && UIManagement.S.waveCurrent >= UIManagement.S.waveTotal && Wave.WAVE_COUNT == 0)
        {
            UIManagement.S.OnWavesEnd();
            Destroy(this);
        }
    }

    protected virtual List<Path> InitializePaths()
    {
        List<Path> paths = new List<Path>();

        return paths;
    }

    protected virtual List<Wave> InitializeWaves(Path path)
    {
        List<Wave> waves = new List<Wave>();
        Wave wave;
        
        // wave 1
        {
            wave = createWaveOnPath(path);
            wave.addEnemiesToWave(createSpawnData(1, 5, 2f));

            waves.Add(wave);
        }
        
        // wave 2
        {
            wave = createWaveOnPath(path);
            wave.addEnemiesToWave(createSpawnData(1, 5, 1f));
            wave.addEnemiesToWave(createSpawnData(2, 5, 2f));

            waves.Add(wave);
        }

        // wave 3
        {
            wave = createWaveOnPath(path);
            wave.addEnemiesToWave(createSpawnData(1, 10, .5f));
            wave.addEnemiesToWave(createSpawnData(2, 10, 1f));
            wave.addEnemiesToWave(createSpawnData(3, 5, 2f));

            waves.Add(wave);
        }

        // wave 4
        {
            wave = createWaveOnPath(path);
            wave.addEnemiesToWave(createSpawnData(1, 20, .25f));
            wave.addEnemiesToWave(createSpawnData(2, 10, .5f));
            wave.addEnemiesToWave(createSpawnData(1, 10, .5f));
            wave.addEnemiesToWave(createSpawnData(3, 10, 2f));

            waves.Add(wave);
        }

        // wave 5
        {
            wave = createWaveOnPath(path);
            wave.addEnemiesToWave(createSpawnData(2, 20, .5f));
            wave.addEnemiesToWave(createSpawnData(3, 20, 1f));

            waves.Add(wave);
        }

        // wave 6
        {
            wave = createWaveOnPath(path);
            wave.addEnemiesToWave(createSpawnData(4, 1, 10f));
            wave.addEnemiesToWave(createSpawnData(2, 10, 1f));

            waves.Add(wave);
        }

        // wave 7
        {
            wave = createWaveOnPath(path);
            wave.addEnemiesToWave(createSpawnData(3, 10, 1f));
            wave.addEnemiesToWave(createSpawnData(4, 1, 5f));
            wave.addEnemiesToWave(createSpawnData(3, 10, 1f));
            wave.addEnemiesToWave(createSpawnData(4, 1, 5f));
            wave.addEnemiesToWave(createSpawnData(3, 10, 1f));
            wave.addEnemiesToWave(createSpawnData(4, 1, 5f));

            waves.Add(wave);
        }

        // wave 8
        {
            wave = createWaveOnPath(path);
            wave.addEnemiesToWave(createSpawnData(1, 30, .25f));
            wave.addEnemiesToWave(createSpawnData(2, 10, .5f));
            wave.addEnemiesToWave(createSpawnData(3, 10, 1f));
            wave.addEnemiesToWave(createSpawnData(4,10, 2f));

            waves.Add(wave);
        }

        // wave 9
        {
            wave = createWaveOnPath(path);
            wave.addEnemiesToWave(createSpawnData(4, 20, 2f));

            waves.Add(wave);
        }

        // wave 10
        {
            wave = createWaveOnPath(path);
            wave.addEnemiesToWave(createSpawnData(3, 20, .25f));
            wave.addEnemiesToWave(createSpawnData(1, 20, .25f));
            wave.addEnemiesToWave(createSpawnData(3, 20, .25f));
            wave.addEnemiesToWave(createSpawnData(1, 20, .25f));
            wave.addEnemiesToWave(createSpawnData(4, 40, .3f));

            waves.Add(wave);
        }
        
        // wave 11
        {
            wave = createWaveOnPath(path);
            wave.addEnemiesToWave(createSpawnData(1, 5, 1f));
            wave.addEnemiesToWave(createSpawnData(5, 1, 5f));
            wave.addEnemiesToWave(createSpawnData(1, 15, 1f));

            waves.Add(wave);
        }
        
        // wave 12
        {
            wave = createWaveOnPath(path);
            wave.addEnemiesToWave(createSpawnData(3, 5, .5f));
            wave.addEnemiesToWave(createSpawnData(5, 1, 10f));
            wave.addEnemiesToWave(createSpawnData(3, 6, 2.5f));

            waves.Add(wave);
        }

        // wave 13
        {
            wave = createWaveOnPath(path);
            wave.addEnemiesToWave(createSpawnData(4, 5, 1f));
            wave.addEnemiesToWave(createSpawnData(5, 1, 10f));
            wave.addEnemiesToWave(createSpawnData(4, 5, 1f));
            wave.addEnemiesToWave(createSpawnData(4, 1, 10f));
            wave.addEnemiesToWave(createSpawnData(5, 1, 10f));

            waves.Add(wave);
        }

        // wave 14
        {
            wave = createWaveOnPath(path);
            wave.addEnemiesToWave(createSpawnData(1, 100, .05f));
            wave.addEnemiesToWave(createSpawnData(5, 1, 0f));
            wave.addEnemiesToWave(createSpawnData(4, 5, 2f));
            wave.addEnemiesToWave(createSpawnData(4, 1, 30f));
            wave.addEnemiesToWave(createSpawnData(5, 1, 0f));
            wave.addEnemiesToWave(createSpawnData(4, 5, 2f));

            waves.Add(wave);
        }

        // wave 15
        {
            wave = createWaveOnPath(path);
            wave.addEnemiesToWave(createSpawnData(2, 50, .1f));
            wave.addEnemiesToWave(createSpawnData(4, 10, .5f));
            wave.addEnemiesToWave(createSpawnData(5, 1, 5f));
            wave.addEnemiesToWave(createSpawnData(4, 10, .5f));
            wave.addEnemiesToWave(createSpawnData(5, 1, 10f));
            wave.addEnemiesToWave(createSpawnData(4, 100, .05f));
            waves.Add(wave);
        }

        return waves;
    }

    public void RunEnemies()
    {
        // check wave limit not met
        if (UIManagement.S.waveCurrent < UIManagement.S.waveTotal)
        {
            // create and run the waves
            createAndRunWaves();
        }
    }

    private void createAndRunWaves()
    {
        foreach( List<Wave> waveList in _waves )
        {
            waveList[UIManagement.S.waveCurrent].run();
        }
        UIManagement.S.waveCurrent++;
    }

    private SpawnData createSpawnData(int enemyID, int numEnemies, float spawnDelay)
    {
        GameObject prefab;

        if( enemyID == 1 )
        {
            prefab = enemyPrefab;
        }
        else if( enemyID == 2 )
        {
            prefab = enemyPrefab2;
        }
        else if (enemyID == 3)
        {
            prefab = enemyPrefab3;
        }
        else if (enemyID == 5)
        {
            prefab = enemyPrefab42;
        }
        else
        {
            prefab = enemyPrefab4;
        }

        SpawnData spawnData = new SpawnData();
        spawnData.enemyDiameter = ENEMY_DIAMETER;
        spawnData.enemyPrefab = prefab;
        spawnData.numEnemies = numEnemies;
        spawnData.delay = spawnDelay;
        return spawnData;
    }

    private Wave createWaveOnPath(Path path)
    {
        Wave wave = null;
        wave = Instantiate(wavePrefab).GetComponent<Wave>();
        wave.SetPath(path);
        return wave;
    }

    // create coordinates that form a circle
    // start/endPercent determine what percentage of the circle the coordinates
    //     start and end at
    public List<Vector3> GenerateCircleCoors(float radiusX, float radiusY,
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
