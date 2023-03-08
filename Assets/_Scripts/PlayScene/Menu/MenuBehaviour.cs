using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{
    [SerializeField] private RectTransform MenuScreen;
    public void OnClickMenuButton()
    {
        Time.timeScale = 0.0f;
        MenuScreen.gameObject.SetActive(true);
    }

    public void OnClickResumeButton()
    {
        MenuScreen.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void OnClickMainMenuButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(Strings.MenuScene);
    }
}
