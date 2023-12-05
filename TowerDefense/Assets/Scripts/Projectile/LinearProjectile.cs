using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearProjectile : EnemyInRange
{
    private int damage = 0;
    private bool rebound;
    private float RangeRadius;
    private float speed;
    private Vector3 initialPosition;
    private bool isDestroyed = false;


    public void Init( Vector3 initialPos, Vector3 direction, 
                      float speed, int initialDamage, 
                      bool reboundPar, float RangeRadius)
    {
        this.RangeRadius = RangeRadius;
        this.initialPosition = initialPos;
        this.transform.position = initialPos;
        this.damage = initialDamage;
        this.rebound = reboundPar;
        this.speed = speed;
        Vector3 vel = direction.normalized;
        vel *= speed;
        this.GetComponent<Rigidbody>().velocity = vel;
        this.orient(direction.normalized);
        eirCollider.Init(GetComponent<EnemyInRange>(), RangeRadius);
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if( enemy != null )
        {
            damageEnemy( enemy );
        }
    }

    private void FixedUpdate()
    {
        if( ( initialPosition - this.transform.position ).magnitude > RangeRadius * 1.2f )
        {
            Destroy(this.gameObject);
        }
    }

    public void damageEnemy( Enemy enemy )
    {
        if( isDestroyed )
        {
            Debug.Log("DESTROYED------------------------------------------");
            return;
        }
        damage -= enemy.health;
        enemy.health = -damage;
        if( rebound && damage > 0 )
        {
            // enemy isn't being destroyed immidiately, 
            //   manually remove from list
            EnemyList.Remove(enemy);
            if(EnemyList.Count > 0)
            {
                // try to predict the last position
                this.transform.position = enemy.transform.position;

                Init(this.transform.position,
                      this.nearestEnemy.transform.position - this.transform.position,
                      this.speed, this.damage, this.rebound, this.RangeRadius);
            }
        }
        else
        {
            isDestroyed = true;
            Destroy(this.gameObject);
        }
    }

    public void orient(Vector3 direction)
    {
        Vector3 rotation = this.transform.eulerAngles;
        // z rotates counter-clockwise where z=0 <=> (x=0,y=1)
        float angle = Mathf.Asin(direction.y);
        if( direction.x < 0 )
        {
            angle = Mathf.PI - angle;
        }
        rotation.z = angle - Mathf.PI / 2;
        rotation.z *= Mathf.Rad2Deg;
        this.transform.eulerAngles = rotation;
    }
}
