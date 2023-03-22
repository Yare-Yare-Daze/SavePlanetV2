using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPlayerScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private AsteroidCollideDetection shieldAsteroidCollideDetection;
    [SerializeField] private Transform bulletPull;

    private List<AsteroidCollideDetection> bulletsACD = new List<AsteroidCollideDetection>();

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        for (int i = 0; i < bulletPull.childCount; i++)
        {
            bulletsACD.Add(bulletPull.GetChild(i).GetComponent<AsteroidCollideDetection>());
            bulletsACD[i].OnCollisionAsteroidDetected += UpdateScoreText;
        }
        shieldAsteroidCollideDetection.OnCollisionAsteroidDetected += UpdateScoreText;
    }

    private void OnDisable()
    {
        shieldAsteroidCollideDetection.OnCollisionAsteroidDetected -= UpdateScoreText;
        for (int i = 0; i < bulletPull.childCount; i++)
        {
            bulletsACD[i].OnCollisionAsteroidDetected -= UpdateScoreText;
        }
    }

    private void UpdateScoreText(GameObject asteroid)
    {
        int sumFromBullets = 0;
        for (int i = 0; i < bulletsACD.Count; i++)
        {
            sumFromBullets += bulletsACD[i].CollisionCount;
        }
        scoreText.text = $"Score: {shieldAsteroidCollideDetection.CollisionCount + sumFromBullets}";
    }
}
