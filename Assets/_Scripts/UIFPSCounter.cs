using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIFPSCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI FPSCounterText;
    private float newDeltaTime;

    private void Update()
    {
        newDeltaTime += (Time.deltaTime - newDeltaTime) * 0.1f;
        float fps = 1.0f / newDeltaTime;
        FPSCounterText.text = "FPS: " + Mathf.Ceil(fps).ToString();
    }

}
