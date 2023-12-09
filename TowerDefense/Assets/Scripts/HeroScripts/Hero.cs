using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// STANDARD: not affected by Enemy42
// NOT_ATTACKING: does not attack
// SLOWED_ATTACKING: heroAttackSpeed is increased
// RANDOM_ATTACKING: Hero1/3 send projectiles in random direction
// FRIENDLY_FIRE: Hero projectiles can destroy other heroes. 
public enum HeroState { STANDARD, NOT_ATTACKING, RANDOM_ATTACKING, FRIENDLY_FIRE, SLOWED_ATTACKING }

public class Hero : EnemyInRange
{
    private bool loaded; // starts loaded
    private bool reloading = false;

    // default damage/speed: override with children
    public virtual int HeroDamage
    {
        get { return 0; }
    }
    public virtual bool startsLoaded
    {
        get { return true; }
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

    // for now, hero will destroy itself whenever health is updated
    public int health
    {
        get { return -1; }
        set { Destroy(this.gameObject); }
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
        loaded = startsLoaded;
        // start reloading when created
        Reload();
        eirCollider.Init(GetComponent<EnemyInRange>(), RangeRadius);
    }

    // Update is called once per frame
    protected void FixedUpdate()
    {
        // update EnemyInRange first
        base.Update();

        // attempt to reload every frame
        Reload();

        // attack if loaded and an enemy exists
        if( loaded && EnemyList.Count > 0 && state != HeroState.NOT_ATTACKING )
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
            // get the attack speed
            float reloadTime = HeroAttackSpeed;
            // increase reloadTime if SLOWED_ATTACKING
            if( state == HeroState.SLOWED_ATTACKING )
            {
                reloadTime *= 5f;
            }

            // start reloading process, finish reloading using attackspeed
            reloading = true;
            Invoke("DoneReloading", reloadTime);
        }
    }

    // called after Reload completed, and only from Reload
    private void DoneReloading()
    {
        // reloading done, set loaded
        loaded = true;
        reloading = false;
    }

    // calcuates direction a projectile needs to move to hit an enemy
    public Vector3 projectAngleToEnemy( Enemy enemy )
    {
        Vector3 heroPos = this.transform.position;
        Vector3 enemyPos = (enemy.pathIter + projectionFrames).pos();
        Vector3 enemyPositionVector = enemyPos - heroPos;
        // apply angle innaccuracy
        enemyPositionVector = Quaternion.Euler(0, 0, angleInaccuracy) * enemyPositionVector;
        return enemyPositionVector;
    }





    ////////////////////////// contact with Projectile //////////////////////
    // times to represent the first/last time the hero was contacted by EnemyProjectile
    private float _timeFirstContact, _timeLastContact;
    private bool hasBeenContacted = false;
    public float timeSinceFirstContact
    {
        get
        {
            return Time.time - _timeFirstContact;
        }
    }

    public float timeSinceLastContact
    {
        get
        {
            return Time.time - _timeLastContact;
        }
    }

    // state based on time since first contact with Projectile42
    public HeroState state
    {
        get
        {
            // not been contacted: standard state
            if( !hasBeenContacted )
            {
                return HeroState.STANDARD;
            }

            // become not contacted after 2 seconds without contact
            if( timeSinceLastContact > 2f )
            {
                hasBeenContacted = false;
            }

            // first phase: not attacking
            if (timeSinceFirstContact < 5f)
            {
                return HeroState.NOT_ATTACKING;
            }
            // second phase: random attacking  - removed due to ability to defeat Enemy5 in this period
            if ( timeSinceFirstContact < 5f )
            {
                return HeroState.RANDOM_ATTACKING;
            }
            // third phase: friendly fire (and random attacking)
            if (timeSinceFirstContact < 15f)
            {
                return HeroState.FRIENDLY_FIRE;
            }
            // last phase (to end): slowed
            return HeroState.SLOWED_ATTACKING;
        }
    }

    // called when contacted by EnemyProjectile
    public void OnContact()
    {
        if( !hasBeenContacted )
        {
            OnFirstContact();
        }
        _timeLastContact = Time.time;
        hasBeenContacted = true;
    }

    // called when contacted by EnemyProjectile and not already contacted
    public void OnFirstContact()
    {
        _timeFirstContact = Time.time;
        loaded = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyProjectile>() != null)
        {
            OnContact();
        }
    }

    public bool friendlyFire
    {
        get { return state == HeroState.FRIENDLY_FIRE; }
    }

    public float angleInaccuracy
    {
        get
        {
            // if attacking randomly, return angle from 0-360
            if (state == HeroState.RANDOM_ATTACKING ||
                 state == HeroState.FRIENDLY_FIRE)
            {
                return Random.value * 360;
            }
            return 0;
        }
    }
}
