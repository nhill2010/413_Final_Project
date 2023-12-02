using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public PathIterator pathIter = null;

    public GameObject healthBarPrefab; // prefab for healthBar
    private HealthBar healthBar;
    private int _health;

    public int health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            healthBar.value = (float)_health / (float)defaultHealth;
            if(_health <= 0)
            {
                UIManagement.S.UpdateMoney(enemyCashValue);
                Destroy(this.gameObject);
            }
        }
    }


    public virtual float enemyCashValue
    {
        get { return 0; }
    }

    public virtual int defaultHealth
    {
        get { return 1; }
    }

    public virtual float damage
    {
        get { return 0; }
    }

    public virtual float speed
    {
        get { return 0; }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject healthbarGO = Instantiate<GameObject>(healthBarPrefab,this.gameObject.transform);
        healthBar = healthbarGO.GetComponent<HealthBar>();
        Vector3 healthBarPos = healthbarGO.transform.position;
        healthBarPos.y = this.transform.position.y + this.transform.localScale.y * 1f;
        healthbarGO.transform.position = healthBarPos;

        // inialize health
        this.health = defaultHealth;
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
                Colony.colonyHealth -= damage;
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


