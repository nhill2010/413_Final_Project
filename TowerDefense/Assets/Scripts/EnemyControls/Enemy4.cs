using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : Enemy
{
    public override float speed
    {
        get { return DefaultStats.enemySpeed4; }
    }

    public override int defaultHealth
    {
        get { return DefaultStats.enemyHealth4;  }
    }

    public override float damage
    {
        get { return DefaultStats.enemyDamageToColony4;  }
    }

    public override int enemyCashValue
    {
        get { return DefaultStats.enemyCashValue4; }
    }
}
