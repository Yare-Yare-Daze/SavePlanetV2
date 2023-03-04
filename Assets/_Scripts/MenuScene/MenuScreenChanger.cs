using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScreenChanger : MonoBehaviour
{
    [SerializeField] private RectTransform mainScreen;
    [SerializeField] private RectTransform settingsScreen;
    [SerializeField] private RectTransform scoreScreen;

    public void OnClickPlayButton()
    {
        SceneManager.LoadScene(Strings.PlayScene);
    }

    public void OnClickSettingsButton()
    {
        mainScreen.gameObject.SetActive(false);
        scoreScreen.gameObject.SetActive(false);
        settingsScreen.gameObject.SetActive(true);
    }

    public void OnClickScoreButton()
    {
        mainScreen.gameObject.SetActive(false);
        settingsScreen.gameObject.SetActive(false);
        scoreScreen.gameObject.SetActive(true);
    }

    public void OnClickHomeButton()
    {
        scoreScreen.gameObject.SetActive(false);
        settingsScreen.gameObject.SetActive(false);
        mainScreen.gameObject.SetActive(true);
    }

}
