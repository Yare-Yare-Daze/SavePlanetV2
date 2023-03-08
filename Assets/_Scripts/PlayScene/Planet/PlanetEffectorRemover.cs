using UnityEngine;

public class PlanetEffectorRemover : MonoBehaviour
{
    [SerializeField] private PlanetGroundAsteroidCollide planetGroundAsteroidCollide;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        planetGroundAsteroidCollide.OnPlanetDestroy += OnPlanetDestroyHandler;
    }

    private void OnDisable()
    {
        planetGroundAsteroidCollide.OnPlanetDestroy -= OnPlanetDestroyHandler;
    }

    private void OnPlanetDestroyHandler()
    {
        gameObject.SetActive(false);
    }
}

