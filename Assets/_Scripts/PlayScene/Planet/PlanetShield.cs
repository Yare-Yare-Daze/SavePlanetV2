using System;
using UnityEngine;

public class PlanetShield : MonoBehaviour
{
    private AsteroidCollideDetection asteroidCollideDetection;
    private int currentHelathPoints;

    [SerializeField] private int maxHealthPoints;

    public event Action OnShieldDeactivated;
    public event Action<int> OnHealthChanged;

    private void Start()
    {
        Initialize();
    }
    private void Initialize()
    {
        currentHelathPoints = maxHealthPoints;
        asteroidCollideDetection = GetComponent<AsteroidCollideDetection>();
        asteroidCollideDetection.OnCollisionAsteroidDetected += ReduceHealthPoints;
        OnHealthChanged?.Invoke(currentHelathPoints); // For correct display score on start stage
    }

    private void OnDisable()
    {
        asteroidCollideDetection.OnCollisionAsteroidDetected -= ReduceHealthPoints;
        OnShieldDeactivated?.Invoke();
    }

    private void ReduceHealthPoints(GameObject asteroid)
    {
        currentHelathPoints = Mathf.Clamp(currentHelathPoints - 1, 0, maxHealthPoints);
        asteroid.GetComponent<AsteroidDestroingParticle>().AsteroidDestroyOnPlanetShield();
        OnHealthChanged?.Invoke(currentHelathPoints);

        if (currentHelathPoints == 0) gameObject.SetActive(false);
    }


}
