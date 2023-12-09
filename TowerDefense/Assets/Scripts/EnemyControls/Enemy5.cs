using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5 : Enemy
{
    public GameObject projectilePrefab = null;
    private bool indestructible;

    public override float speed
    {
        get { return DefaultStats.enemySpeed5; }
    }

    public override int defaultHealth
    {
        get { return DefaultStats.enemyHealth5; }
    }

    public override float damage
    {
        get { return DefaultStats.enemyDamageToColony5; }
    }

    public override int enemyCashValue
    {
        get { return DefaultStats.enemyCashValue5; }
    }

    public override int health
    {
        get
        {
            return base.health;
        }
        set
        {
            bool takingDamage = value < base.health;
            // only take damage if not taking damage or not indestructible
            if( !takingDamage || !indestructible )
            {
                base.health = value;
            }
        }
    }

    protected new void Start()
    {
        // indestructible for 1 second to allow projectiles to affect heroes first
        indestructible = true;
        Invoke("SetIndestructibleFalse", DefaultStats.IndestructibleDuration );
        InvokeRepeating("Attack", 0, DefaultStats.EnemyAttackSpeed5);
        base.Start();
    }

    private void SetIndestructibleFalse()
    {
        indestructible = false;
    }
    
    public void Attack()
    {
        EnemyProjectile projectile = Instantiate<GameObject>(projectilePrefab).GetComponent<EnemyProjectile>();
        projectile.Init(this.transform.position, 
                        DefaultStats.EnemyProjectileSpeed5, 
                        DefaultStats.EnemyRangeRadius5);
    }
}
