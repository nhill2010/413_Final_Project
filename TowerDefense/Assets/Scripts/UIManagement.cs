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
    public Text moneyText,
                wavesText,
                hero1Inv,
                hero2Inv,
                hero3Inv;
    public int money, h1Amt, h2Amt, h3Amt;
    public int waveTotal = 10;
    // public PlayerInfo playerInfo;

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
        h1Amt = PlayerPrefs.GetInt( "Hero1Inventory" );
        hero1Inv.text = "" + h1Amt;
        h2Amt = PlayerPrefs.GetInt( "Hero2Inventory" );
        hero2Inv.text = "" + h2Amt;
        h3Amt = PlayerPrefs.GetInt( "Hero3Inventory" );
        hero3Inv.text = "" + h3Amt;
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
        money += moneyDifference;
        PlayerPrefs.SetInt( "Bank", money );
    }
    
    public void UpdateInventory( heroType H, int amt )
    {
        switch( H )
        {
            case heroType.hero1:
                h1Amt += amt;
                PlayerPrefs.SetInt( "Hero1Inventory", h1Amt );
                hero1Inv.text = "" + h1Amt;
                break;
            case heroType.hero2:
                h2Amt += amt;
                PlayerPrefs.SetInt( "Hero2Inventory", h2Amt );
                hero2Inv.text = "" + h2Amt;
                break;
            case heroType.hero3:
                h3Amt += amt;
                PlayerPrefs.SetInt( "Hero3Inventory", h3Amt );
                hero3Inv.text = "" + h3Amt;
                break;
        }
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

    public void OnWavesEnd()
    {
        Debug.Log("Completed Waves");
        SceneManager.LoadScene("WinScreen");
    }

}
