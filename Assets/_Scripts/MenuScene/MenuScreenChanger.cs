using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScreenChanger : MonoBehaviour
{
    [SerializeField] private RectTransform mainScreen;
    [SerializeField] private RectTransform settingsScreen;

    public void OnClickPlayButton()
    {
        SceneManager.LoadScene(Strings.PlayScene);
    }

    public void OnClickSettingsButton()
    {
        mainScreen.gameObject.SetActive(false);
        settingsScreen.gameObject.SetActive(true);
    }

    public void OnClickHomeButton()
    {
        mainScreen.gameObject.SetActive(true);
        settingsScreen.gameObject.SetActive(false);
    }

}
