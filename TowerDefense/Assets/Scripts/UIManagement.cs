using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/********* OUTLINE **********
* Colony health bar ( top center )
* Gold earned ( top left corner )
* Waves x/total ( top right corner )
* Select / purchase hero ( button on bottom left screen - opens new scene via scene management )
*/


public class UIManagement : MonoBehaviour
{
    // singleton for UI management
    static private  UIManagement S;

    // these variables are set in Unity
    [ Header( "Set in Inspector" ) ]
    public Text moneyText;
    public Text wavesText;
    public float money;
    public int waveTotal = 10;

    // these variables are set during runtime
    [ Header( "Set Dynamically" ) ]
    public Button changeHeroButton;
    public GameObject healthBarPrefab;
    public Slider colonyHealthBar;
    public float healthLvl;
    public int waveCurrent = 1;

    void Start()
    {
        S = this;
        colonyHealthBar = healthBarPrefab.gameObject.GetComponent<Slider>();
        healthLvl = 1f;
        money = 0.0f; // later this will be pulled from stored player data
        moneyText.text = string.Format( "${0:#0.0}", money );
    }

    void Update()
    {
        moneyText.text = "$" + money;
        wavesText.text = "Wave " + waveCurrent + " / " + waveTotal;
        healthLvl = 0.4f;
        UpdateHealth();
    }

    void UpdateHealth()
    {
        Color color = colonyHealthBar.GetComponentsInChildren<Image>()[0].color;
        // if colony has been hit:
        // reduce health by certain amount ( different for each enemy )

        // this part doesn't work currently
        if ( healthLvl <= 0.75f )
        {
            // change color to yellow
            color = new Color( 255, 255, 0 );
        }
        if ( healthLvl <= 0.5f )
        {
            // change color to orange
            color = new Color( 255, 127, 0 );
        }
        if ( healthLvl < 0.25f )
        {
            // change color to red
            color = new Color( 255, 3, 0 );
        }
    }
}
