using UnityEngine;

public class PlanetRotating : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Vector3 rotateDirection;

    private void FixedUpdate()
    {
        transform.Rotate(rotateDirection, rotateSpeed * Time.deltaTime);
    }
}
