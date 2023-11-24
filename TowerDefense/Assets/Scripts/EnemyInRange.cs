using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class EnemyInRange : MonoBehaviour
{

    [Header("Dynamic")]
    public List<Enemy> EnemyList;
    private SphereCollider coll;
    public float heroattackspeed = 2f;
    public int HeroDamage = 2;
    // Start is called before the first frame update
    void Start()
    {
        EnemyList = new List<Enemy>();
        coll = GetComponent<SphereCollider>();
        InvokeRepeating("AttackEnemy", heroattackspeed, heroattackspeed);
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
            EnemyList[0].health -= HeroDamage;
        }
    }
}
