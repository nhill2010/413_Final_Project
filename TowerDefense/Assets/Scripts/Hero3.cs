using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero3 : Hero
{
    public override int HeroDamage
    {
        get { return 3; }
    }
    public override float HeroAttackSpeed
    {
        get { return 2.0f; }
    }
    public override float RangeRadius
    {
        get { return 5.0f; }
    }


    // HeroDamage divided among any number of enemies
    public override void Attack()
    {
        int remainingDamage = HeroDamage;
        // iterate over all enemies
        foreach (Enemy enemy in EnemyList)
        {
            // attack enemy for remaining damage
            enemy.health -= remainingDamage;

            // convert extra damage into remainingDamage
            remainingDamage = Mathf.Max(-enemy.health,0);

            // stop if no damage remaining
            if( remainingDamage <= 0 )
            {
                break;
            }
        }
    }
}
