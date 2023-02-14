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
        Debug.Log(rb2d.velocity.normalized);
        var newShape = asteroidTrail.shape;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection;

        newDirection = Vector3.RotateTowards(transform.forward, rb2d.velocity, 1f, 0.0f);
        
        

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
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
            

        //asteroidTrail.shape.rotation = Quaternion.FromToRotation(asteroidTrail.transform.localPosition, rb2d.velocity);
    }
}
