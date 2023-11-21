using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colony : MonoBehaviour
{

    [Header( "Inscribed" ) ]

    public float colonyHealth;

    // public Rigidbody colony;

    // Start is called before the first frame update
    void Start()
    {
        colonyHealth = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollsionEnter( Collision collision )
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if( enemy != null )
        {
            colonyHealth -= enemy.stats.damageToColony;

            //this may need to be changed if we decide to make a DESTROY_ENEMY() elsewhere.
            Destroy( enemy );
        }
    }
}
