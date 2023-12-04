using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    public override float speed
    {
        get { return DefaultStats.enemySpeed1; }
    }

    public override int defaultHealth
    {
        get { return DefaultStats.enemyHealth1; }
    }

    public override float damage
    {
        get { return DefaultStats.enemyDamageToColony1; }
    }

    public override int enemyCashValue
    {
        get { return DefaultStats.enemyCashValue1; }
    }
}
