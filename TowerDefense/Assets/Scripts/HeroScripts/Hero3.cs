using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero3 : Hero
{
    public GameObject linearProjectilePrefab;

    public override int HeroDamage
    {
        get { return 4; }
    }
    public override float HeroAttackSpeed
    {
        get { return .75f; }
    }
    public override float RangeRadius
    {
        get { return 7.0f; }
    }
    public float projectileSpeed
    {
        get { return 100f; }
    }

    public override int projectionFrames
    {
        get { return 1; }
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
                            projectEnemyPosition( enemyClosestToColony ) - this.transform.position,
                            projectileSpeed, HeroDamage, false, RangeRadius);
        }
    }

}
