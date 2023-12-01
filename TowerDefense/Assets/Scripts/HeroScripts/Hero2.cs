using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hero2 : Hero
{
    public override int HeroDamage
    {
        get { return 1; }
    }
    public override float HeroAttackSpeed
    {
        get { return 3.0f; }
    }
    public override float RangeRadius
    {
        get { return 5.0f; }
    }


    public override void Attack()
    {
        // attack all enemies in the list
        foreach( Enemy enemy in EnemyList )
        {
            enemy.health -= HeroDamage;
        }
    }
}
