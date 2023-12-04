using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeroSelectScreen : MonoBehaviour
{

    public Button Hero1, Hero2, Hero3;
    public Text h1T, h2T, h3T, moneyText;
    public int h1Price = 100,
                h2Price = 250,
                h3Price = 500;
    public int h1Amt, h2Amt, h3Amt;
    public Text h1AmtT, h2AmtT, h3AmtT;
    static public int money;

    void Awake()
    {
        if( PlayerPrefs.HasKey( "Bank" ) ) {
            money = PlayerPrefs.GetInt( "Bank" );
        }
        if ( PlayerPrefs.HasKey( "Hero1Inventory" ) ) {
            h1Amt = PlayerPrefs.GetInt( "Hero1Inventory" );
        }
        if ( PlayerPrefs.HasKey( "Hero2Inventory" ) ) {
            h2Amt = PlayerPrefs.GetInt( "Hero2Inventory" );
        }
        if ( PlayerPrefs.HasKey( "Hero3Inventory" ) ) {
            h3Amt = PlayerPrefs.GetInt( "Hero3Inventory" );
        }

        PlayerPrefs.SetInt( "Bank", money );
        PlayerPrefs.SetInt( "Hero1Inventory", h1Amt );
        PlayerPrefs.SetInt( "Hero2Inventory", h2Amt );
        PlayerPrefs.SetInt( "Hero3Inventory", h3Amt );

        moneyText.text = "$" + money;
    }

    void Start()
    {
        // add button listeners
	    Hero1.onClick.AddListener( delegate{ Purchase( h1Amt, h1Price ); } );
        Hero2.onClick.AddListener( delegate{ Purchase( h2Amt, h2Price ); } );
        Hero3.onClick.AddListener( delegate{ Purchase( h3Amt, h3Price ); } );

        // initialize button text
        h1T.text = "$" + h1Price;
        h2T.text = "$" + h2Price;
        h3T.text = "$" + h3Price;
    }

    void Update()
    {
        if( money != PlayerPrefs.GetInt( "Bank" ) ) {
            PlayerPrefs.SetInt( "Bank", money );
        }

        moneyText.text = "$" + money;
    }

    void Purchase( int amt, int price )
    {
        // get current number of heros
        // add 1 to hero count
        amt++; // not sure if this will work

        // subtract price from total money\
        // money = PlayerPrefs.GetInt( "Bank" );
        // money -= price;
        // PlayerPrefs.SetInt( "Bank", money );
        if ( PlayerPrefs.GetInt( "Bank" ) >= 100 ) { // hardcoded to lowest hero price
            UIManagement.S.UpdateMoney( -price );
            money = PlayerPrefs.GetInt( "Bank" );
        }
        else {
            // print error message to screen
            PlayerPrefs.SetInt( "Bank", 0 );
        }
    }
}
