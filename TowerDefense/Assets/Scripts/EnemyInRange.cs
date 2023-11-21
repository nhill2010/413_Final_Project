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
            Debug.Log(b.name);
            if(b != null)
            {
                Debug.Log("Not NUll");
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
}
