using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero3 : Hero
{
    public GameObject linearProjectilePrefab;

    public override int HeroDamage
    {
        get { return DefaultStats.HeroDamage3; }
    }
    public override float HeroAttackSpeed
    {
        get { return DefaultStats.HeroAttackSpeed3; }
    }
    public override float RangeRadius
    {
        get { return DefaultStats.RangeRadius3; }
    }

    public float projectileSpeed
    {
        get { return DefaultStats.projectileSpeed3; }
    }

    public override int projectionFrames
    {
        get { return DefaultStats.projectionFrames3; }
    }


    // HeroDamage divided among any number of enemies
    public override void Attack()
    {
        // verify at least one enemy exists
        if (EnemyList.Count >= 1)
        {
            // create a projectile
            GameObject projectileGO = Instantiate<GameObject>(linearProjectilePrefab);
            LinearProjectile projectile = projectileGO.GetComponent<LinearProjectile>();

            // initialize the projectile in the direction of the nearest enemy
            projectile.Init(this.transform.position,
                            projectAngleToEnemy(enemyClosestToColony),
                            projectileSpeed, HeroDamage, false, RangeRadius, friendlyFire, this);
        }
    }

}
