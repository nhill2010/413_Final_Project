using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    public override float speed
    {
        get { return DefaultStats.enemySpeed2; }
    }

    public override int defaultHealth
    {
        get { return DefaultStats.enemyHealth2;  }
    }

    public override float damage
    {
        get { return DefaultStats.enemyDamageToColony2;  }
    }

    public override int enemyCashValue
    {
        get { return DefaultStats.enemyCashValue2; }
    }
}
