using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScorePlayerPrefs : MonoBehaviour
{
    [SerializeField] private AsteroidCollideDetection asteroidCollideDetection;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        asteroidCollideDetection.OnCollisionAsteroidDetected += UpdatePlayerPrefsScoreValue;
    }

    private void UpdatePlayerPrefsScoreValue(GameObject go)
    {
        if(PlayerPrefs.GetInt(Strings.ScoreValue) < asteroidCollideDetection.CollisionCount)
        {
            PlayerPrefs.SetInt(Strings.ScoreValue, asteroidCollideDetection.CollisionCount);
        }
    }
}
