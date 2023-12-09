using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private bool rebound;
    private float RangeRadius;
    private float speed;
    private Vector3 initialPosition;

    public void Init(Vector3 initialPos, float speed,
                      float RangeRadius)
    {
        this.RangeRadius = RangeRadius;
        this.initialPosition = initialPos;
        this.transform.position = initialPos;
        this.speed = speed;
    }

    private void FixedUpdate()
    {
        Vector3 scale = this.transform.localScale;
        // destroy projectile after reached RangeRadius
        if (scale.x > RangeRadius )
        {
            Destroy(this.gameObject);
        }
        else
        {
            // increase the size of this
            scale.x += speed;
            scale.y += speed;
            // set z scale of smaller projectiles higher to make them visible 
            scale.z = ( RangeRadius * 2f - scale.x ) * 1f;
            this.transform.localScale = scale;

            // set position behind physical path
            Vector3 thisPos = this.transform.position;
            thisPos.z = 12f;
            this.transform.position = thisPos;

            // set the collider.position.z=0 and collider.radius=this.scale.x
            {
                // set z position to 0
                Vector3 colliderPos = this.GetComponent<SphereCollider>().center;
                colliderPos.z = -this.transform.position.z / this.transform.localScale.z;
                this.GetComponent<SphereCollider>().center = colliderPos;


                // set radius to x-scale (assume x=y)
                // SphereCollider's radius at .5 will encapsulate the object's largest radius
                float radius;
                // case largest radius is x
                if (this.transform.localScale.z <= this.transform.localScale.x)
                {
                    // raidus=.5f will match x's scale
                    radius = .5f;
                }
                // otherwise, z is largest radius
                else
                {
                    // radius=.5f will match z's scale
                    // rescale to x's scale
                    radius = .5f * (this.transform.localScale.x / this.transform.localScale.z);
                }
                this.GetComponent<SphereCollider>().radius = radius;
            }
        }
    }
}
