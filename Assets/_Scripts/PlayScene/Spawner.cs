using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Vector3 leftTopCorner;
    private Vector3 rightTopCorner;
    private Vector3 leftbottomCorner;
    private Vector3 rightBottomCorner;

    [SerializeField] private GameObject spawnObject;
    [SerializeField] private float maxSpawnTime;
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float timeForMaxLevel;

    private float currentSpawnTime = 0;
    private float currentLimitSpawnTime;
    private float timePassedFromStart = 0;

    private void Awake()
    {
        Initialize();
        
    }

    private void Update()
    {
        timePassedFromStart += Time.deltaTime;
        currentSpawnTime += Time.deltaTime;
        float reductionTimeRate = maxSpawnTime - (maxSpawnTime * (timePassedFromStart / timeForMaxLevel));
        currentLimitSpawnTime = Mathf.Clamp(reductionTimeRate, minSpawnTime, maxSpawnTime);
        if (currentSpawnTime > currentLimitSpawnTime)
        {
            toSpawnObject();
            currentSpawnTime = 0;
        }
        
    }

    private void Initialize()
    {
        leftTopCorner = Camera.main.ViewportToWorldPoint(new Vector2(0f, 1f));
        rightTopCorner = Camera.main.ViewportToWorldPoint(new Vector2(1f, 1f));
        leftbottomCorner = Camera.main.ViewportToWorldPoint(new Vector2(0f, 0f));
        rightBottomCorner = Camera.main.ViewportToWorldPoint(new Vector2(1f, 0f));
        currentLimitSpawnTime = maxSpawnTime;
    }

    private void toSpawnObject()
    {
        bool isTopSpawn = Random.value > 0.5f ? true : false;
        Vector3 spawnPosition = Vector3.zero;
        if (isTopSpawn)
        {
            spawnPosition = new Vector3(Random.Range(leftTopCorner.x, rightTopCorner.x), leftTopCorner.y, 0);
            spawnPosition += Vector3.up;
        }
        else
        {
            spawnPosition = new Vector3(Random.Range(leftbottomCorner.x, rightBottomCorner.x), leftbottomCorner.y, 0);
            spawnPosition += Vector3.down;
        }

        var obj = Instantiate(spawnObject, spawnPosition, Quaternion.identity);

    }
}
