using UnityEngine;

public class SceneLoader : MonoBehaviour
{

    public void GoBack()
    {
        SceneManager.LoadPreviousScene();
    }

    public void LoadScene( string name )
    {
        SceneManager.LoadScene( name );
    }
}
