using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private static SceneManager instance;
    private static bool destroyed = false;
    private static object lockObject = new object();
    private Stack<int> loadedLevels;

    public static SceneManager Instance
    {
        get {
            if ( destroyed ) {
                // already destroyed
                Debug.LogError( "already destroyed. Returning null" );
                return null;
            }

            lock ( lockObject ) {
                if ( instance == null ) {
                    instance = ( SceneManager ) FindObjectOfType( typeof( SceneManager ) );

                    if ( instance == null ) {
                        var singletonObject = new GameObject();
                        instance = singletonObject.AddComponent<SceneManager>();
                        singletonObject.name = typeof( SceneManager ).ToString() + " (Singleton)";

                        DontDestroyOnLoad( singletonObject );
                    }
                }

                return instance;
            }
        }
    }
    public static UnityEngine.SceneManagement.Scene GetActiveScene()
    {
        return UnityEngine.SceneManagement.SceneManager.GetActiveScene();
    }

    public static void LoadScene( string name )
    {
        Instance.loadedLevels.Push( GetActiveScene().buildIndex );
        UnityEngine.SceneManagement.SceneManager.LoadScene( name );
    }
    
    public static void LoadScene( int buildIdx )
    {
        Instance.loadedLevels.Push( GetActiveScene().buildIndex );
        UnityEngine.SceneManagement.SceneManager.LoadScene( buildIdx );
    }

    public static void LoadPreviousScene()
    {
        if ( Instance.loadedLevels.Count > 0 ) {
            UnityEngine.SceneManagement.SceneManager.LoadScene( Instance.loadedLevels.Pop() );
        }
        else {
            Debug.LogError( "No previous screen to load" );
        }
    }

/*     public void GoBack( )
    {
        if ( Instance.loadedLevels.Count > 0 ) {
            UnityEngine.SceneManagement.SceneManager.LoadScene( Instance.loadedLevels.Pop() );
        }
        else {
            Debug.LogError( "No previous screen to load" );
        }
        // SceneManager.LoadScene( prevScreen );
    }
 */
    private void Awake()
    {
        loadedLevels = new Stack<int>();
    }

    private void OnApplicationQuit()
    {
        destroyed = true;
    }

    private void OnDestroy()
    {
        destroyed = true;
    }
}
