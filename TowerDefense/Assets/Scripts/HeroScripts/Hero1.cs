using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero1 : Hero
{
    public GameObject linearProjectilePrefab;

    public override int HeroDamage
    {
        get { return 5; }
    }
    public override float HeroAttackSpeed
    {
        get { return 1.5f; }
    }
    public override float RangeRadius
    {
        get { return 7.5f; }
    }

    public float projectileSpeed
    {
        get { return 75f; }
    }

    public override int projectionFrames
    {
        get { return 1; }
    }

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
                            projectileSpeed, HeroDamage, true, RangeRadius);
        }
    }
}
