using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum heroType { hero1, hero2, hero3 };

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
	    Hero1.onClick.AddListener( delegate{ Purchase( heroType.hero1 ); } );
        Hero2.onClick.AddListener( delegate{ Purchase( heroType.hero2 ); } );
        Hero3.onClick.AddListener( delegate{ Purchase( heroType.hero3 ); } );

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

    void Purchase( heroType H )
    {
        int price;
        switch( H ) {
            case heroType.hero1:
                h1Amt++;
                price = h1Price;
                break;
            case heroType.hero2:
                h2Amt++;
                price = h2Price;
                break;
            case heroType.hero3:
                h3Amt++;
                price = h3Price;
                break; 
            default:
                price = 0;
                break;
        }

        // UIManagement.S.UpdateInventory( h1Amt, h2Amt, h3Amt );
        PlayerPrefs.SetInt( "Hero1Inventory", h1Amt );
        PlayerPrefs.SetInt( "Hero2Inventory", h2Amt );
        PlayerPrefs.SetInt( "Hero3Inventory", h3Amt );

        if ( PlayerPrefs.GetInt( "Bank" ) >= 100 ) { // hardcoded to lowest hero price
            UIManagement.S.UpdateMoney( -price );
            money = PlayerPrefs.GetInt( "Bank" );
        }
        else {
            // TODO: print error message to screen
            PlayerPrefs.SetInt( "Bank", 0 );
        }
    }
}
