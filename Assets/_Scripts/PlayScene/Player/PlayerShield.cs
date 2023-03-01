using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    private AsteroidCollideDetection asteroidCollideDetection;
    private int countDestroiedAsteroids;


    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        asteroidCollideDetection = GetComponent<AsteroidCollideDetection>();
        asteroidCollideDetection.OnCollisionAsteroidDetected += CollisionAsteroidDetectedHandler;
        countDestroiedAsteroids = 0;
    }

    private void OnDisable()
    {
        asteroidCollideDetection.OnCollisionAsteroidDetected -= CollisionAsteroidDetectedHandler;
    }

    private void CollisionAsteroidDetectedHandler(GameObject asteroid)
    {
        countDestroiedAsteroids++;
        Debug.Log("countDestroiedAsteroids: " + countDestroiedAsteroids);
        asteroid.GetComponent<AsteroidDestroingParticle>().AsteroidDestroy();
    }
}
