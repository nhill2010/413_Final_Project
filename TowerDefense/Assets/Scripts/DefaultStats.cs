using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// note: prefabs are not assigned, adding get/set might work
public class DefaultStats : MonoBehaviour
{
    //////////////////////////// enemy ////////////////////////////////////////
    [HideInInspector]
    public static float enemySpeed1 = .1f;
    public static int enemyHealth1 = 2;
    public static float enemyDamageToColony1 = .1001f;
    public static int enemyCashValue1 = 10;

    [HideInInspector]
    public static float enemySpeed2 = .15f;
    public static int enemyHealth2 = 6;
    public static float enemyDamageToColony2 = .2001f;
    public static int enemyCashValue2 = 50;

    [HideInInspector]
    public static float enemySpeed3 = .12f;
    public static int enemyHealth3 = 10;
    public static float enemyDamageToColony3 = .2501f;
    public static int enemyCashValue3 = 100;

    [HideInInspector]
    public static float enemySpeed4 = .07f;
    public static int enemyHealth4 = 35;
    public static float enemyDamageToColony4 = .3501f;
    public static int enemyCashValue4 = 150;

    [HideInInspector]
    public static float enemySpeed5 = .035f;
    public static int enemyHealth5 = 10;
    public static float enemyDamageToColony5 = .05f;
    public static int enemyCashValue5 = 0;
    public static float EnemyAttackSpeed5 = .5f;
    public static float IndestructibleDuration = 1f;
    public static float EnemyProjectileSpeed5 = .5f;
    public static float EnemyRangeRadius5 = 20f;

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

    ///////////////////////////// Player //////////////////////////////////
    
    [HideInInspector]
    public static int PlayerStartMoney = 500;




    ///////////////////////////// projectile //////////////////////////////////
}
