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
        /*
        if(true) // used to reset PlayerPref's values
        {
            Debug.Log("Resetting Bank's value. Note: This can be undone in HeroSelectScreen.Awake()");
            PlayerPrefs.SetInt("Hero1Inventory", 0);
            PlayerPrefs.SetInt("Hero2Inventory", 0);
            PlayerPrefs.SetInt("Hero3Inventory", 0);
            PlayerPrefs.SetInt("Bank", 500);
        }
        */

        if ( PlayerPrefs.HasKey( "Bank" ) ) {
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
        string HeroInventory; // contains the hero's variable name
        // get price and HeroInventory from heroType
        switch( H ) {
            case heroType.hero1:
                price = h1Price;
                HeroInventory = "Hero1Inventory";
                break;
            case heroType.hero2:
                price = h2Price;
                HeroInventory = "Hero2Inventory";
                break;
            case heroType.hero3:
                price = h3Price;
                HeroInventory = "Hero3Inventory";
                break; 
            default:
                Debug.Log("WARNING: Attempted to purchase invalid heroType");
                // exit the function
                return;
        }

        // check able to purchase hero
        if ( PlayerPrefs.GetInt( "Bank" ) >= price )
        {
            // update money at 3 differnet locations? 
            UIManagement.S.UpdateMoney(-price);
            money -= price;
            PlayerPrefs.SetInt("Bank",money);

            // increment hero inventory
            PlayerPrefs.SetInt(HeroInventory, PlayerPrefs.GetInt(HeroInventory) + 1);
        }
        // otherwise, unable to purchase hero
        else
        {
            // TODO: print error message to screen
            Debug.Log("Not succesful");
        }

        // update hAmts
        h1Amt = PlayerPrefs.GetInt("Hero1Inventory");
        h2Amt = PlayerPrefs.GetInt("Hero2Inventory");
        h3Amt = PlayerPrefs.GetInt("Hero3Inventory");
    }

    public void DeletePlayerData()
    {
        PlayerPrefs.DeleteAll();
    }
}
