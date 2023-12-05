using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;

public class EnemyInRange : MonoBehaviour
{

    [Header("Dynamic")]
    public List<Enemy> EnemyList;
    public GameObject EIRColliderPrefab;
    public EIRCollider eirCollider;

    // Start is called before the first frame update
    void Awake()
    {
        EnemyList = new List<Enemy>();
        eirCollider = Instantiate<GameObject>(EIRColliderPrefab).GetComponent<EIRCollider>();
    }

    // Update is called once per frame
    protected void Update()
    {
        EnemyList.RemoveAll(b=>b==null);        
    }

    public Enemy nearestEnemy
    {
        get
        {
            Update();
            if( EnemyList.Count == 0 )
            {
                return null;
            }
            Enemy leastDistanceEnemy = (Enemy)EnemyList[0];
            float leastDistance = (leastDistanceEnemy.transform.position -
                                    this.transform.position).magnitude;
            foreach( Enemy testEnemy in EnemyList)
            {
                float testDistance = (testEnemy.transform.position -
                                      this.transform.position).magnitude;
                if( testDistance < leastDistance )
                {
                    leastDistanceEnemy = testEnemy;
                    leastDistance = testDistance;
                }
            }
            return leastDistanceEnemy;
        }
    }

    public Enemy enemyClosestToColony
    {
        get
        {
            Update();
            if (EnemyList.Count == 0)
            {
                return null;
            }
            Enemy closestEnemy = (Enemy)EnemyList[0];
            foreach (Enemy testEnemy in EnemyList)
            {
                if (testEnemy.pathIter > closestEnemy.pathIter)
                {
                    closestEnemy = testEnemy;
                }
            }
            return closestEnemy;
        }
    }
    
    public void OnDestroy()
    {
        if (eirCollider != null &&
            eirCollider.gameObject != null)
        {
            Destroy(eirCollider.gameObject);
        }
    }
    
}
