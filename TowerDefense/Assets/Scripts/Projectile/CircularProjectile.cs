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


    public void Init(Vector3 initialPos, float speed, 
                      int damage, float RangeRadius)
    {
        this.RangeRadius = RangeRadius;
        this.initialPosition = initialPos;
        this.transform.position = initialPos;
        this.damage = damage;
        this.speed = speed;
        eirCollider.Init(GetComponent<EnemyInRange>(), RangeRadius);
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            damageEnemy(enemy);
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
}
