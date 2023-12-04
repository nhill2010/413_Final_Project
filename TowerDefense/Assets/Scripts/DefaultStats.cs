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

    public static float enemySpeed2 = .15f;
    public static int enemyHealth2 = 6;
    public static float enemyDamageToColony2 = .2f;
    public static int enemyCashValue2 = 300;

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
    public static int HeroDamage3 = 4;
    public static float HeroAttackSpeed3 = .75f;
    public static float RangeRadius3 = 7.0f;
    public static float projectileSpeed3 = 75f;
    public static int projectionFrames3 = 4;

    ///////////////////////////// projectile //////////////////////////////////
}
