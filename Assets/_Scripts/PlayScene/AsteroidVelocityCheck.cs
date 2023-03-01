using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AsteroidVelocityCheck : MonoBehaviour
{
    [SerializeField] private ParticleSystem asteroidTrail;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var newShape = asteroidTrail.shape;

        Vector3 newDirection;
        newDirection = Vector3.RotateTowards(transform.forward, rb2d.velocity, 1f, 0.0f);

        Debug.DrawRay(transform.forward, newDirection, Color.red);

        transform.rotation = Quaternion.LookRotation(newDirection);
        newShape.rotation = Quaternion.LookRotation(newDirection).eulerAngles;

        if (rb2d.velocity.y > 0)
        {
            newShape.rotation *= 1;
        }
        else
        {
            newShape.rotation *= -1;
        }
    }
}
