using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
   public void LoadGameScene()
   {
        SceneManager.LoadScene(1);
   }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void LoadMenuScene()
    {
        SceneManager.LoadScene(0);

    }
}
