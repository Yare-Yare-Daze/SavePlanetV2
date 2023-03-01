using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILoseScreen : MonoBehaviour
{
    [SerializeField] private PlanetGroundAsteroidCollide planetGroundAsteroidCollide;
    [SerializeField] private GameObject loseScreen;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        planetGroundAsteroidCollide.OnPlanetDestroy += ActivateLoseScreen;
    }

    private void OnDisable()
    {
        planetGroundAsteroidCollide.OnPlanetDestroy -= ActivateLoseScreen;
    }

    private void ActivateLoseScreen()
    {
        loseScreen.SetActive(true);
    }
}
