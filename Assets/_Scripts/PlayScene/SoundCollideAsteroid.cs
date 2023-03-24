using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCollideAsteroid : MonoBehaviour
{
    [Header("AsteroidCollideDetection component")]
    [SerializeField] private AsteroidCollideDetection ACD;
    [SerializeField] private AudioSource collideSound;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        ACD.OnCollisionAsteroidDetected += ACDHadler;
    }

    private void ACDHadler(GameObject asteroid)
    {
        collideSound.Play();
    }

}
