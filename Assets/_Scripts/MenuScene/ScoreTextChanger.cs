using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTextChanger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI maxScoreValueText;
    [SerializeField] private TextMeshProUGUI lastScoreValueText;

    private void OnEnable()
    {
        Debug.Log("Enabled!");
        if(PlayerPrefs.HasKey(Strings.MaxScoreValue))
        {
            maxScoreValueText.text = PlayerPrefs.GetInt(Strings.MaxScoreValue).ToString();
        }
        else
        {
            PlayerPrefs.SetInt(Strings.MaxScoreValue, 0);
            maxScoreValueText.text = "0";
        }

        if (PlayerPrefs.HasKey(Strings.LastScoreValue))
        {
            lastScoreValueText.text = PlayerPrefs.GetInt(Strings.LastScoreValue).ToString();
        }
        else
        {
            PlayerPrefs.SetInt(Strings.LastScoreValue, 0);
            lastScoreValueText.text = "0";
        }
    }
}
