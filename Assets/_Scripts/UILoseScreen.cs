using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILoseScreen : MonoBehaviour
{
    [SerializeField] private PlanetGround planetGround;
    [SerializeField] private GameObject loseScreen;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        planetGround.OnPlanetDestroy += ActivateLoseScreen;
    }

    private void OnDisable()
    {
        planetGround.OnPlanetDestroy -= ActivateLoseScreen;
    }

    private void ActivateLoseScreen()
    {
        loseScreen.SetActive(true);
    }
}
