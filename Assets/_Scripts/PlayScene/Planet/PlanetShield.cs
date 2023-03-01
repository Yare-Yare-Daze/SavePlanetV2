using System;
using UnityEngine;

public class PlanetShield : MonoBehaviour
{
    private AsteroidCollideDetection asteroidCollideDetection;
    private int helathPoints;

    [SerializeField] private int maxHealthPoints;

    public event Action OnShieldDeactivated;
    public event Action<int> OnHealthChanged;

    private void Awake()
    {
        Initialize();
    }
    private void Initialize()
    {
        helathPoints = maxHealthPoints;
        asteroidCollideDetection = GetComponent<AsteroidCollideDetection>();
        asteroidCollideDetection.OnCollisionAsteroidDetected += ReduceHealthPoints;
    }

    private void OnDisable()
    {
        asteroidCollideDetection.OnCollisionAsteroidDetected -= ReduceHealthPoints;
        OnShieldDeactivated?.Invoke();
    }

    private void ReduceHealthPoints(GameObject asteroid)
    {
        helathPoints = Mathf.Clamp(helathPoints - 1, 0, maxHealthPoints);
        asteroid.GetComponent<AsteroidDestroingParticle>().AsteroidDestroyOnPlanetShield();
        OnHealthChanged?.Invoke(helathPoints);

        if (helathPoints == 0) gameObject.SetActive(false);
    }


}
