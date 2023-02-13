using UnityEngine;

public class Spawner : MonoBehaviour
{
    protected Vector3 leftTopCorner;
    protected Vector3 rightTopCorner;
    protected Vector3 leftbottomCorner;
    protected Vector3 rightBottomCorner;

    [SerializeField] protected GameObject spawnObject;
    [SerializeField] private float spawnTime;

    private float currentSpawnTime = 0;

    private void Start()
    {
        initCornersFields();
        //Debug.Log("leftbottomCorner: " + leftbottomCorner);
        //Debug.Log("rightBottomCorner: " + rightBottomCorner);
    }

    private void Update()
    {
        currentSpawnTime += Time.deltaTime;
        if(currentSpawnTime > spawnTime)
        {
            toSpawnObject();
            currentSpawnTime = 0;
        }
        
    }

    protected void initCornersFields()
    {
        leftTopCorner = Camera.main.ViewportToWorldPoint(new Vector2(0f, 1f));
        rightTopCorner = Camera.main.ViewportToWorldPoint(new Vector2(1f, 1f));
        leftbottomCorner = Camera.main.ViewportToWorldPoint(new Vector2(0f, 0f));
        rightBottomCorner = Camera.main.ViewportToWorldPoint(new Vector2(1f, 0f));
    }

    protected void toSpawnObject()
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

        Instantiate(spawnObject, spawnPosition, Quaternion.identity);
    }
}
