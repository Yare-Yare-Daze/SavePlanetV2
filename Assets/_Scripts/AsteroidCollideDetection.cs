using System;
using UnityEngine;

public class AsteroidCollideDetection : MonoBehaviour
{
    private int collisionCount = 0;
    public event Action<GameObject> OnCollisionAsteroidDetected; 

    public int CollisionCount { get { return collisionCount; } }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Debug.Log(gameObject.name + " detected collision with asteroid");
            OnCollisionAsteroidDetected?.Invoke(collision.transform.parent.gameObject);
            
            collisionCount++;
        }
    }
}
