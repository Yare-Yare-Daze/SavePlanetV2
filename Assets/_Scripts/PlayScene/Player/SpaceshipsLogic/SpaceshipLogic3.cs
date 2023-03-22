using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipLogic3 : MonoBehaviour
{
    [SerializeField] private PlanetGroundAsteroidCollide planetGroundAsteroidCollide;
    [SerializeField] private Transform bulletPull;
    [SerializeField] private float timeSpawn = 1f;
    [SerializeField] private Transform leftGunEndPosition;
    [SerializeField] private Transform rightGunEndPosition;

    private int currentBulletIndex = 0;
    private bool isGameFinished = false;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        planetGroundAsteroidCollide.OnPlanetDestroy += GameFinished;
        StartCoroutine(SpawnBullet());
    }

    private void GameFinished()
    {
        isGameFinished = true;
    }

    private IEnumerator SpawnBullet()
    {
        while(!isGameFinished)
        {
            Transform leftBullet = GetCurrentBulletAndIncreaseCounter();
            Transform rightBullet = GetCurrentBulletAndIncreaseCounter();

            leftBullet.transform.position = leftGunEndPosition.position;
            rightBullet.transform.position = rightGunEndPosition.position;

            leftBullet.gameObject.SetActive(true);
            rightBullet.gameObject.SetActive(true);

            yield return new WaitForSeconds(timeSpawn);
        }
    }

    private Transform GetCurrentBulletAndIncreaseCounter()
    {
        Transform bullet = bulletPull.GetChild(currentBulletIndex);
        currentBulletIndex++;
        if (currentBulletIndex > bulletPull.childCount - 1) currentBulletIndex = 0;
        return bullet;
    }

}
