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

    // these variables are set during runtime
    [ Header( "Set Dynamically" ) ]


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
