using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// class for EnemyStats: 
// speed and prefab are only used for the Wave
// other values can be added here as needed
public class EnemyStats
{
    public float speed;
    public GameObject prefab;
    public int testVal;
}

public class Enemy : MonoBehaviour
{
    PathIterator pathIter = null;

    // stats for enemy, will be set when created by wave
    public EnemyStats stats;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if the path has been defined, advance the position
        if( pathIter != null )
        {
            pathIter++;
            transform.position = pathIter.pos();
            // if the iterator ended, destroy this
            if( pathIter.End() )
            {
                Debug.Log("Completed Path: testVal = " + stats.testVal.ToString());
                Destroy(this.gameObject);
            }
        }
    }

    // sets the enemy onto the start of the path
    public void SetOnPath(Path path,float speed)
    {
        pathIter = path.Begin(speed);
        transform.position = pathIter.pos();
    }
}


