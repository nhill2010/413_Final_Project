using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;



public class SpawnData
{
    public int numEnemies;
    public float delay;
    public GameObject enemyPrefab;
    public float enemyDiameter;
}

public class WaveSegment
{
    public SpawnData spawnData;
}


/* 
 * Only inherits from MonoBehaviour to delay between function calls. 
 * This script may be attatched to any object, but must not be destroyed
 *      before the wave's enemies are done spawning. 
 */
public class Wave : MonoBehaviour
{
    List<WaveSegment> waveSegments;
    Path enemyPath;
    public static int WAVE_COUNT = 0;

    public void SetPath( Path wavePath )
    {
        waveSegments = new List<WaveSegment>();
        enemyPath = wavePath;
    } 

    public void addEnemiesToWave( SpawnData enemySpawnData )
    {
        WaveSegment waveSegment = new WaveSegment();
        waveSegment.spawnData = enemySpawnData;
        waveSegments.Add(waveSegment);
    }

    public void run()
    {
        WAVE_COUNT++;
        _running_waveSegmentIndex = -1;
        _running_remainingEnemies = 0;
        recursiveGenerateEnemy();
    }

    // variables only used in recursiveGenerateEnemy
    private float           _running_remainingEnemies;
    private int             _running_waveSegmentIndex;
    private WaveSegment     _running_waveSegmentCurrent;
    public void recursiveGenerateEnemy()
    {
        // update current wave segment if no enemies remaining
        if (_running_remainingEnemies <= 0)
        {
            _running_waveSegmentIndex++;
            if (_running_waveSegmentIndex >= waveSegments.Count)
            {
                WAVE_COUNT--;
                return;
            }
            _running_waveSegmentCurrent = waveSegments[_running_waveSegmentIndex];
            _running_remainingEnemies = _running_waveSegmentCurrent.spawnData.numEnemies;
        }

        // instantiate a new enemy
        GameObject newEnemy = Instantiate(_running_waveSegmentCurrent.spawnData.enemyPrefab);
        // set enemy on the path
        newEnemy.GetComponent<Enemy>().SetOnPath(enemyPath);
        newEnemy.transform.localScale = Vector3.one * _running_waveSegmentCurrent.spawnData.enemyDiameter;

        // recurse with one less enemy
        _running_remainingEnemies--;
        Invoke("recursiveGenerateEnemy", _running_waveSegmentCurrent.spawnData.delay);
    }
}


