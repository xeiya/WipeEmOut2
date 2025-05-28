using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSceneByBuildIndex(int buildIndex) 
    {
        //Load the scene with the given build index
        SceneManager.LoadScene(buildIndex);
    }
}
