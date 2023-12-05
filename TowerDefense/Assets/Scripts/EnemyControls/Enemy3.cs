using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Enemy
{
    public override float speed
    {
        get { return DefaultStats.enemySpeed3; }
    }

    public override int defaultHealth
    {
        get { return DefaultStats.enemyHealth3;  }
    }

    public override float damage
    {
        get { return DefaultStats.enemyDamageToColony3;  }
    }

    public override int enemyCashValue
    {
        get { return DefaultStats.enemyCashValue3; }
    }
}
