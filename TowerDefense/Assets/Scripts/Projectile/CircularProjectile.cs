using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularProjectile : EnemyInRange
{
    private int damage = 0;
    private bool rebound;
    private float RangeRadius;
    private float speed;
    private Vector3 initialPosition;
    private bool friendlyFire;
    private Hero source;


    public void Init(Vector3 initialPos, float speed, 
                      int damage, float RangeRadius, bool friendlyFire, 
                      Hero source)
    {
        this.RangeRadius = RangeRadius;
        this.initialPosition = initialPos;
        this.transform.position = initialPos;
        this.damage = damage;
        this.speed = speed;
        this.friendlyFire = friendlyFire;
        this.source = source;
        eirCollider.Init(GetComponent<EnemyInRange>(), RangeRadius);
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            damageEnemy(enemy);
        }
        Hero hero = other.GetComponentInParent<Hero>();
        if( hero != null )
        {
            damageHero(hero);
        }
    }

    private void FixedUpdate()
    {
        Vector3 scale = this.transform.localScale;
        if(scale.x > RangeRadius * 2f)
        {
            Destroy(this.gameObject);
        }
        else
        {
            scale.x += speed;
            scale.y += speed;
            this.transform.localScale = scale;
        }
    }

    public void damageEnemy(Enemy enemy)
    {
        enemy.health -= damage;
    }
    public void damageHero(Hero hero)
    {
        if (ReferenceEquals(hero, source)) return;
        if (!friendlyFire) return;
        hero.health -= damage;
    }
}
