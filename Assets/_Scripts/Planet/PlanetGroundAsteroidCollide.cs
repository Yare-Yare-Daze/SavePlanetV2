using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGroundAsteroidCollide : MonoBehaviour
{
    [SerializeField] private float reductionSpeed;
    [SerializeField] private ParticleSystem planetDestroyParticle;
    private AsteroidCollideDetection asteroidCollideDetection;

    public event Action OnPlanetDestroy;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        asteroidCollideDetection = GetComponent<AsteroidCollideDetection>();
        asteroidCollideDetection.OnCollisionAsteroidDetected += AsteroidCollideHandler;
    }

    private void OnDisable()
    {
        asteroidCollideDetection.OnCollisionAsteroidDetected -= AsteroidCollideHandler;
    }

    private void AsteroidCollideHandler(GameObject asteroid)
    {
        asteroid.GetComponent<AsteroidDestroingParticle>().AsteroidDestroy();
        StartCoroutine(ScaleReductionPlanet());
        StartCoroutine(DestructionPlanetParticle());
        OnPlanetDestroy?.Invoke();
    }

    private IEnumerator ScaleReductionPlanet()
    {
        while(gameObject.activeSelf == true)    
        {
            yield return new WaitForFixedUpdate();
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, reductionSpeed * Time.deltaTime);
            if (transform.localScale == Vector3.zero)
                gameObject.SetActive(false);
        }
    }
    private IEnumerator DestructionPlanetParticle()
    {
        planetDestroyParticle.gameObject.SetActive(true);
        yield return new WaitForSeconds(planetDestroyParticle.main.duration);
        planetDestroyParticle.gameObject.SetActive(false);
    }
}
