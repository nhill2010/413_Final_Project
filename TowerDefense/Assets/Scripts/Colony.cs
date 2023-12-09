using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colony : MonoBehaviour
{

    [Header( "Inscribed" ) ]

    public static float colonyHealth;

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

    private void OnTriggerEnter( Collider collider )
    {
        Enemy enemy = collider.gameObject.GetComponent<Enemy>();

        if( enemy != null )
        {
            colonyHealth -= enemy.damage;

            //this may need to be changed if we decide to make a DESTROY_ENEMY() elsewhere.
            Destroy( enemy.gameObject );
            if(colonyHealth <= 0 )
            {
                SceneManager.LoadScene("LoseScreen");
            }
        }
    }
}
