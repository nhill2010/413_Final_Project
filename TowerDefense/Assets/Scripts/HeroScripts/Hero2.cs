using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hero2 : Hero
{
    public GameObject circularProjectilePrefab;

    public override int HeroDamage
    {
        get { return 1; }
    }
    public override float HeroAttackSpeed
    {
        get { return 1.5f; }
    }
    public override float RangeRadius
    {
        get { return 5.0f; }
    }

    public float projectileSpeed
    {
        get { return 2.0f; }
    }


    public override void Attack()
    {
        // attack all enemies in the list
        GameObject projectileGO = Instantiate<GameObject>(circularProjectilePrefab);
        CircularProjectile projectile = projectileGO.GetComponent<CircularProjectile>();

        // initialize the projectile in the direction of the nearest enemy
        projectile.Init(this.transform.position,
                        projectileSpeed, HeroDamage, RangeRadius);
    }
}
