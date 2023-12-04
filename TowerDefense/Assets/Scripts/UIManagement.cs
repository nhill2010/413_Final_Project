using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/********* OUTLINE **********
* Colony health bar ( top center )
* Gold earned ( top left corner )
* Waves x/total ( top right corner )
* Select / purchase hero ( button on bottom left screen - opens new scene via scene management )
*/


public class UIManagement : MonoBehaviour
{
    // singleton for UI management
    static public UIManagement S = null;

    // these variables are set in Unity
    [ Header( "Set in Inspector" ) ]
    public Text moneyText;
    public Text wavesText;
    public int money;
    public int waveTotal = 10;

    // these variables are set during runtime
    [ Header( "Set Dynamically" ) ]
    public Button changeHeroButton;
    public GameObject healthBarPrefab;
    public Slider colonyHealthBar;
    public float healthLvl;
    public int waveCurrent = 0;

    void Awake()
    {
        S = this;
        colonyHealthBar = healthBarPrefab.gameObject.GetComponent<Slider>();
        healthLvl = 1f;

        if( PlayerPrefs.HasKey( "Bank" ) ) {
            money = PlayerPrefs.GetInt( "Bank" );
        }
        PlayerPrefs.SetInt( "Bank", money );

        moneyText.text = string.Format( "${0:#0.0}", money );

    }

    void Update()
    {
        moneyText.text = "$" + money;
        wavesText.text = "Wave " + waveCurrent + " / " + waveTotal;
        healthLvl = 1f;
        UpdateHealth();

        // set money in player prefs
        if( money != PlayerPrefs.GetInt( "Bank" ) ) {
            PlayerPrefs.SetInt( "Bank", money );
        }
    }

    // called when enemies are destroyed or
    // when heroes are purchased
    public void UpdateMoney(int moneyDifference)
    {
        // on enemy destroy:
        // if ( Enemy.enemyDestroyed )
        // {
        //float reward = enemyStats.enemyCashValue;
        money += moneyDifference;
        PlayerPrefs.SetInt( "Bank", money );
        // }

    }

    void UpdateHealth()
    {
        // get health value from Colony script
        healthLvl = Colony.colonyHealth;
        colonyHealthBar.value = healthLvl;

        // red, green, blue
        // scale red from 0 to 1, 
        // scale green from 1 to 0
        Color color = colonyHealthBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color;
        color.b = 0;
        color.g = colonyHealthBar.value;
        color.r = 1 - colonyHealthBar.value;
        colonyHealthBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = color;
    }

}
