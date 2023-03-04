using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTextChanger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreValueText;

    private void OnEnable()
    {
        Debug.Log("Enabled!");
        if(PlayerPrefs.HasKey(Strings.ScoreValue))
        {
            scoreValueText.text = PlayerPrefs.GetInt(Strings.ScoreValue).ToString();
        }
        else
        {
            PlayerPrefs.SetInt(Strings.ScoreValue, 0);
            scoreValueText.text = "0";
        }
    }
}
