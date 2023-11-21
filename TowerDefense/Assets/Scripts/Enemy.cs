using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// class for EnemyStats: 
// speed, prefab, and diameter are only used in Wave
// other values can be added here as needed
public class EnemyStats
{
    public float speed;
    public GameObject prefab;
    public float diameter;
    public int health;
    public float damageToColony; 
    public float enemyCashValue; // how much money they are worth when destroyed
}

public class Enemy : MonoBehaviour
{
    PathIterator pathIter = null;
    
    // stats for enemy, will be set when created by wave
    public EnemyStats stats;
    public UIManagement UI;
    
    // Start is called before the first frame update
    void Start()
    {
        stats.enemyCashValue = 100f;
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
                pathIter = null;
                UIManagement.S.healthLvl -= stats.damageToColony;
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

    // attack the enemy for damage, destroy if <0 health
    // return true if enemy was defeated
    public bool attackEnemy(int damage)
    {
        this.stats.health -= damage;
        if (this.stats.health <= 0)
        {
            UIManagement.S.UpdateMoney(stats.enemyCashValue);
            Destroy(this.gameObject);
            return true;
        }
        return false;
    }

}


