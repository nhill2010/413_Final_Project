using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero1 : Hero
{
    public override int HeroDamage
    {
        get { return 5; }
    }
    public override float HeroAttackSpeed
    {
        get { return 1.0f; }
    }
    public override float RangeRadius
    {
        get { return 7.5f; }
    }

    public override void Attack()
    {
        // verify at least one enemy exists
        if (EnemyList.Count >= 1)
        {
            // damage the enemy
            EnemyList[0].health -= HeroDamage;
        }
    }
}
