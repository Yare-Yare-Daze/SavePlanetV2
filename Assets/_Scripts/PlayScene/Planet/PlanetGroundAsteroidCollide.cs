using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGroundAsteroidCollide : MonoBehaviour
{
    [SerializeField] private float reductionSpeed;
    [SerializeField] private ParticleSystem planetDestroyParticle;
    [SerializeField] private CircleCollider2D circleCollider2D;
    [SerializeField] private float timeStartEmissionExplode;
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
        circleCollider2D.enabled = false;
        asteroid.GetComponent<AsteroidDestroingParticle>().AsteroidDestroy();
        StartCoroutine(ScaleReductionPlanet());
        StartCoroutine(DestructionPlanetParticle());
        OnPlanetDestroy?.Invoke();
    }

    private IEnumerator ScaleReductionPlanet()
    {
        float spentTime = 0f;
        while(spentTime <= timeStartEmissionExplode)    
        {
            Vector3 newPosShake = UnityEngine.Random.insideUnitCircle;

            yield return new WaitForFixedUpdate();

            transform.position = Vector3.Lerp(transform.position, newPosShake, reductionSpeed * Time.deltaTime);
            spentTime += Time.deltaTime;

            if (spentTime > timeStartEmissionExplode)
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
