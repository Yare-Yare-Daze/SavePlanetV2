using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPlayerScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private AsteroidCollideDetection asteroidCollideDetection;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        asteroidCollideDetection.OnCollisionAsteroidDetected += UpdateScoreText;
    }

    private void OnDisable()
    {
        asteroidCollideDetection.OnCollisionAsteroidDetected -= UpdateScoreText;
    }

    private void UpdateScoreText(GameObject asteroid)
    {
        scoreText.text = $"Score: {asteroidCollideDetection.CollisionCount}";
    }
}
