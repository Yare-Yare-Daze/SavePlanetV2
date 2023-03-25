using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDisableEndGame : MonoBehaviour
{
    [SerializeField] private PlanetGroundAsteroidCollide pgac;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        pgac.OnPlanetDestroy += DisabePlayer;
    }

    private void DisabePlayer()
    {
        gameObject.SetActive(false);
    }
}
