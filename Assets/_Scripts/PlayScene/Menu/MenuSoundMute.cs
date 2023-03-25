using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSoundMute : MonoBehaviour
{
    [SerializeField] private RectTransform soundOnButton;
    [SerializeField] private RectTransform soundOffButton;

    private bool isMutted = false;

    private void Awake()
    {
        isMutted = PlayerPrefs.GetInt(Strings.MuteValue) == 1;
        ChangeButtonIcon();
    }

    private void ChangeButtonIcon()
    {
        if (isMutted)
        {
            soundOnButton.gameObject.SetActive(false);
            soundOffButton.gameObject.SetActive(true);
        }
        else
        {
            soundOnButton.gameObject.SetActive(true);
            soundOffButton.gameObject.SetActive(false);
        }
    }

    public void MuteButton()
    {
        isMutted = !isMutted;
        AudioListener.pause = isMutted;
        PlayerPrefs.SetInt(Strings.MuteValue, isMutted ? 1 : 0);
        ChangeButtonIcon();
    }
}
