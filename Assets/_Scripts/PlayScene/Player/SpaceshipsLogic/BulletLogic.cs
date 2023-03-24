using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    [SerializeField] private AsteroidCollideDetection asteroidCollideDetection;
    [SerializeField] private Transform playerSpaceship;

    private Rigidbody2D rb2D;

    private void OnEnable()
    {
        if(rb2D == null) rb2D = GetComponent<Rigidbody2D>();

        asteroidCollideDetection.OnCollisionAsteroidDetected += AsteroidCollideHandler;
        rb2D.AddForce(playerSpaceship.up * speed);

        StartCoroutine(LifeTimeEnd());
        //Debug.Log(transform.name + " enabled!");
    }

    private void OnDisable()
    {
        asteroidCollideDetection.OnCollisionAsteroidDetected -= AsteroidCollideHandler;
    }

    private IEnumerator LifeTimeEnd()
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }

    private void AsteroidCollideHandler(GameObject asteroid)
    {
        asteroid.GetComponent<AsteroidDestroingParticle>().AsteroidDestroy();
        gameObject.SetActive(false);
    }
}
