using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    public Button rules, levels, store;

    void Start()
    {
        rules.onClick.AddListener( Rules );
        levels.onClick.AddListener( Levels );
        store.onClick.AddListener( Store );
    }

    void Rules()
    {
        SceneManager.LoadScene( "HelpScreen" );
    }

    void Levels()
    {
        SceneManager.LoadScene( "LevelSelect" );
    }

    void Store()
    {
        SceneManager.LoadScene( "HeroSelectScreen" );
    }

}
