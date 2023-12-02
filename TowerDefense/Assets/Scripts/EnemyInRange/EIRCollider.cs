using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EIRCollider : MonoBehaviour
{
    EnemyInRange parent;
    private SphereCollider coll;

    public void Init( EnemyInRange parentPar, float radius )
    {
        this.parent = parentPar;
        coll = GetComponent<SphereCollider>();
        coll.radius = radius;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy b = other.GetComponent<Enemy>();
            if (b != null)
            {
                if (!parent.EnemyList.Contains(b))
                {
                    parent.EnemyList.Add(b);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Enemy b = other.GetComponent<Enemy>();
        if (b != null)
        {
            parent.EnemyList.Remove(b);
        }
    }

    public void Update()
    {    
        if( parent != null)
            this.transform.position = parent.transform.position;
    }
}
