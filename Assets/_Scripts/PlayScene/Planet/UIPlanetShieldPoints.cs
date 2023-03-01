using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPlanetShieldPoints : MonoBehaviour
{
    [SerializeField] private PlanetShield planetShield;
    [SerializeField] private TextMeshProUGUI planetShieldPointsText;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        planetShield.OnHealthChanged += ChangeText;
    }

    private void OnDisable()
    {
        planetShield.OnHealthChanged -= ChangeText;
    }

    private void ChangeText(int shieldPoints)
    {
        planetShieldPointsText.text = "Shield points: " + shieldPoints;
    }
}
