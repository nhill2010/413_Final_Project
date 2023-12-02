using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : EnemyInRange
{
    private bool loaded = true; // starts loaded
    private bool reloading = false;

    // default damage/speed: override with children
    public virtual int HeroDamage
    {
        get { return 0; }
    }
    public virtual float HeroAttackSpeed
    {
        get { return 1f; }
    }
    public virtual float RangeRadius
    {
        get { return 0f; }
    }

    public virtual int projectionFrames
    {
        get { return 0; }
    }

    // Attack is the only function to be overwritten by children
    public virtual void Attack()
    {
        // verify at least one enemy exists
        if (EnemyList.Count >= 1)
        {
            // damage the enemy
            EnemyList[0].health -= HeroDamage;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        // start reloading when created
        Reload();
        eirCollider.Init(GetComponent<EnemyInRange>(), RangeRadius);
    }

    // Update is called once per frame
    protected void FixedUpdate()
    {
        // update EnemyInRange first
        base.Update();

        // attack if loaded and an enemy exists
        if( loaded && EnemyList.Count > 0 )
        {
            Attack();
            // set to not loaded, then reload
            loaded = false;
            Reload();
        }
    }

    public void Reload()
    {
        // do not allow reload while already reloading
        //   or already loaded
        if( !reloading && !loaded )
        {
            // start reloading process, finish reloading using attackspeed
            reloading = true;
            Invoke("DoneReoading", HeroAttackSpeed);
        }
    }

    // called after Reload completed, and only from Reload
    private void DoneReoading()
    {
        // reloading done, set loaded
        loaded = true;
        reloading = false;
    }

    public Vector3 projectEnemyPosition(Enemy enemy)
    {
        return (enemy.pathIter + projectionFrames).pos();
    }
}
