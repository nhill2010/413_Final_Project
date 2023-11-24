using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : EnemyInRange
{
    public bool loaded = false; // starts not loaded
    public float heroattackspeed = 2f;
    public int HeroDamage = 2;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Reload", heroattackspeed);
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        // update EnemyInRange first
        base.Update();

        // attack if loaded and an enemy exists
        if( loaded && EnemyList.Count > 0 )
        {
            Attack();
        }
    }

    private void Attack()
    {
        // verify at least one enemy exists
        if (EnemyList.Count >= 1)
        {
            // damage the enemy
            EnemyList[0].health -= HeroDamage;
        }
        // set to not loaded, begin to reload
        loaded = false;
        Invoke("Reload", heroattackspeed);

    }

    private void Reload()
    {
        loaded = true;
    }
}
