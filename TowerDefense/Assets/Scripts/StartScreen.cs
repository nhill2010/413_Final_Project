using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        // UIManagement.S.money = DefaultStats.PlayerStartMoney;
        int pMoney; 

        if( PlayerPrefs.HasKey( "Bank" ) ) {
            pMoney = PlayerPrefs.GetInt( "Bank" );
        }

        if( PlayerPrefs.GetInt( "Bank" ) < DefaultStats.PlayerStartMoney )
        {
            pMoney = DefaultStats.PlayerStartMoney;
            PlayerPrefs.SetInt( "Bank", pMoney );
        }

        // PlayerPrefs.SetInt( "Bank", pMoney );
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
