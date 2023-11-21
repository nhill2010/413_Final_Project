using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInRange : MonoBehaviour
{

    [Header("Dynamic")]
    public List<Enemy> EnemyList;
    private SphereCollider coll;
    // Start is called before the first frame update
    void Start()
    {
        EnemyList = new List<Enemy>();
        coll = GetComponent<SphereCollider>();
         InvokeRepeating("AttackEnemy", 2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyList.RemoveAll(b=>b==null);

        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Enemy"))
        {
            Enemy b = other.GetComponent<Enemy>();
            if(b != null)
            {
                if(!EnemyList.Contains(b))
                {
                    EnemyList.Add(b);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Enemy b = other.GetComponent<Enemy>();
        if(b!=null)
        {
            EnemyList.Remove(b);
        }
    }

    private void AttackEnemy()
    {
        if ( EnemyList.Count >= 1 )
        {
            Debug.Log("hello");
            EnemyList[0].attackEnemy(2);
        }
    }
}
