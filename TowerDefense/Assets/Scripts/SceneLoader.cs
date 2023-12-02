using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    static public SceneLoader S = null; // Singleton
    
    private string start = "StartScreen";
    // private string store = "HeroSelectScreen";
    // private string help = "HelpScreen";
    // private string levels = "LevelSelect";
    // private string level0 = "_Scene_0";
    // private string level1 = "_Scene_1";
    // private string level2 = "_Scene_2";
    // private string level3 = "_Scene_3";
    private string prevScreen;
    private string currScreen = "StartScreen";

    void Start()
    {
        prevScreen = currScreen;
        currScreen = SceneManager.GetActiveScene().name;
    }

    public void LoadScene( string name )
    {
        prevScreen = currScreen;
        currScreen = name;
        Debug.Log( "curr1: " + currScreen );
        Debug.Log( "prev1: " + prevScreen );
        SceneManager.LoadScene( name );
    }

    public void GoBack( )
    {
        SceneManager.LoadScene( prevScreen );
    }
}
