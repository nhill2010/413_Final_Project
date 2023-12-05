using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// note: prefabs are not assigned, adding get/set might work
public class DefaultStats : MonoBehaviour
{
    //////////////////////////// enemy ////////////////////////////////////////
    [HideInInspector]
    public static float enemySpeed1 = .1f;
    public static int enemyHealth1 = 2;
    public static float enemyDamageToColony1 = .1f;
    public static int enemyCashValue1 = 100;

    [HideInInspector]
    public static float enemySpeed2 = .15f;
    public static int enemyHealth2 = 6;
    public static float enemyDamageToColony2 = .2f;
    public static int enemyCashValue2 = 300;

    [HideInInspector]
    public static float enemySpeed3 = .12f;
    public static int enemyHealth3 = 10;
    public static float enemyDamageToColony3 = .25f;
    public static int enemyCashValue3 = 400;

    [HideInInspector]
    public static float enemySpeed4 = .07f;
    public static int enemyHealth4 = 35;
    public static float enemyDamageToColony4 = .35f;
    public static int enemyCashValue4 = 500;

    ////////////////////////// hero //////////////////////////////////////////
    [HideInInspector]
    public static int HeroDamage1 = 5;
    public static float HeroAttackSpeed1 = 1.5f;
    public static float RangeRadius1 = 7.5f;
    public static float projectileSpeed1 = 75f;
    public static int projectionFrames1 = 1;

    [HideInInspector]
    public static int HeroDamage2 = 1;
    public static float HeroAttackSpeed2 = 1.5f;
    public static float RangeRadius2 = 5.0f;
    public static float projectileSpeed2 = 2.0f;
    public static int projectionFrames2 = 0;

    [HideInInspector]
    public static int HeroDamage3 = 1;
    public static float HeroAttackSpeed3 = .20f;
    public static float RangeRadius3 = 6.0f;
    public static float projectileSpeed3 = 85f;
    public static int projectionFrames3 = 3;

    ///////////////////////////// projectile //////////////////////////////////
}
