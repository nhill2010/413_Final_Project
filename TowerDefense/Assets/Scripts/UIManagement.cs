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
    public float money;
    public int waveTotal = 10;

    // these variables are set during runtime
    [ Header( "Set Dynamically" ) ]
    public Button changeHeroButton;
    public GameObject healthBarPrefab;
    public Slider colonyHealthBar;
    public float healthLvl;
    public int waveCurrent = 4;
    public EnemyStats enemyStats;
    void Start()
    {
        S = this;
        colonyHealthBar = healthBarPrefab.gameObject.GetComponent<Slider>();
        healthLvl = 1f;
        money = 0f; // later this will be pulled from stored player data
        moneyText.text = string.Format( "${0:#0.0}", money );

        changeHeroButton.onClick.AddListener( HeroSelect );
    }

    void Update()
    {
        moneyText.text = "$" + money;
        wavesText.text = "Wave " + waveCurrent + " / " + waveTotal;
        healthLvl = 1f;
        UpdateHealth();
    }

    // called when enemies are destroyed or
    // when heroes are purchased
    public void UpdateMoney(float moneyDifference)
    {
        // on enemy destroy:
        // if ( Enemy.enemyDestroyed )
        // {
        //float reward = enemyStats.enemyCashValue;
        money += moneyDifference;
        // }

        // on hero purchase:
        // if ( Hero.heroPurchased )
        // {
        //     // change the name of this
        //     float payment = Hero.money;
        //     money -= payment;
        // }
    }

    void UpdateHealth()
    {
        // get health value from Colony script
        healthLvl = Colony.colonyHealth;
        colonyHealthBar.value = healthLvl;

        // this will be responsible for changing the color of the health bar
        // based on the level
        // CURRENTLY: does not work
        
        // var fill = colonyHealthBar.GetComponentsInChildren<Image>().FirstOrDefault( t => t.name == "Fill" );
        // if ( fill != null )
        // {
        //     Debug.Log( fill.gameObject.tag );
        //     // Debug.Log( fill.color );
        //     // Color color = colonyHealthBar.GetComponentsInChildren<Image>()[0].color;
        //     // if colony has been hit:
        //     // reduce health by certain amount ( different for each enemy )

        //     if ( healthLvl < 0.25f )
        //     {
        //         // change color to red
        //         fill.color = new Color( 255, 3, 0 );
        //         Debug.Log( fill.color );
        //     }            
        //     else if ( healthLvl <= 0.5f )
        //     {
        //         // change color to orange
        //         fill.color = new Color( 255, 127, 0 );
        //         Debug.Log( fill.color );
        //     }
        //     else if ( healthLvl <= 0.75f )
        //     {
        //         // change color to yellow
        //         fill.color = new Color( 255, 255, 0 );
        //         Debug.Log( fill.color );
        //     }
        //     else
        //     {
        //         fill.color = new Color( 50, 255, 0 );
        //         Debug.Log( fill.color );
        //     }
        // }
    }

    void HeroSelect()
    {
        Debug.Log( "BUTTON PRESSED" );
        SceneManager.LoadScene( "HeroSelectScene" );
    }
}
