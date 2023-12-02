using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hero2 : Hero
{
    public GameObject circularProjectilePrefab;


    public override int HeroDamage
    {
        get { return DefaultStats.HeroDamage2; }
    }
    public override float HeroAttackSpeed
    {
        get { return DefaultStats.HeroAttackSpeed2; }
    }
    public override float RangeRadius
    {
        get { return DefaultStats.RangeRadius2; }
    }

    public float projectileSpeed
    {
        get { return DefaultStats.projectileSpeed2; }
    }

    public override int projectionFrames
    {
        get { return DefaultStats.projectionFrames2; }
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
