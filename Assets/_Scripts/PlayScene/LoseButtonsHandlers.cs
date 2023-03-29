using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseButtonsHandlers : MonoBehaviour
{
    public void HomeButtonHandler()
    {
        SceneManager.LoadScene(Strings.MenuScene);
    }

    public void RetryButtonHandler()
    {
        SceneManager.LoadScene(Strings.PlayScene);
    }
}
