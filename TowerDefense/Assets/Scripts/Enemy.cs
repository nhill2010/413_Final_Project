using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// class for EnemyStats: 
// other values can be added here as needed
public class EnemyStats
{
    public float speed;
    public int health;
    public float damageToColony; 
    public float enemyCashValue; // how much money they are worth when destroyed
    public EnemyStats(EnemyStats statsPar)
    {
        speed = statsPar.speed;
        health = statsPar.health;
        damageToColony = statsPar.damageToColony;
        enemyCashValue = statsPar.enemyCashValue;
    }
    public EnemyStats() { }
}

public class Enemy : MonoBehaviour
{
    PathIterator pathIter = null;

    // stats for enemy, will be set when created by wave
    private EnemyStats _stats;


    // only used to initialize _stats
    public EnemyStats stats
    {
        // make a copy of the parameter
        set 
        { 
            // require positive health
            if( value.health <= 0f )
            {
                throw new Exception("Attempted to Initialize non-positive Health");
            }
            _stats = new EnemyStats(value); 
        }
    }

    public int health
    {
        get
        {
            return _stats.health;
        }
        set
        {
            _stats.health = value;
            if(_stats.health <= 0)
            {
                UIManagement.S.UpdateMoney(_stats.enemyCashValue);
                Destroy(this.gameObject);
            }
        }
    }

    public float damage
    {
        get { return _stats.damageToColony; }
        set { _stats.damageToColony = value; }
    }

    public float speed
    {
        get { return _stats.speed; }
        set 
        {
            _stats.speed = value;
            pathIter.speed = _stats.speed;
        }
    }
    
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
                pathIter = null;
                Colony.colonyHealth -= _stats.damageToColony;
                Destroy(this.gameObject);
            }
        }
    }

    // sets the enemy onto the start of the path
    public void SetOnPath(Path path)
    {
        pathIter = path.Begin(speed);
        transform.position = pathIter.pos();
    }
}


