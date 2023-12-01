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
    static public int money = 0;

    void Awake()
    {
        if( PlayerPrefs.HasKey( "Bank" ) ) {
            money = PlayerPrefs.GetInt( "Bank" );
        }

        PlayerPrefs.SetInt( "Bank", money );

        moneyText.text = "$" + money;
    }

    void Start()
    {
        // add button listeners
	    Hero1.onClick.AddListener( delegate{ Purchase( h1Price ); } );
        Hero2.onClick.AddListener( delegate{ Purchase( h2Price ); } );
        Hero3.onClick.AddListener( delegate{ Purchase( h3Price ); } );

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
    }

    void Purchase( int price )
    {
        // get current number of heros
        // add 1 to hero count

        // subtract price from total money
        money -= price;
    }
}
