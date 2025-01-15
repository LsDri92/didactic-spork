using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeSceneWithTransition(string sceneName)
    {
        Initiate.Fade(sceneName, Color.magenta, 1.5f);
        SceneManager.LoadScene(sceneName);
    }

}
