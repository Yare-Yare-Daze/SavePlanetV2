using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform planetTransform;

    [HideInInspector] public Vector3 direction;
    [HideInInspector] public int multiplier = 1;

    private void FixedUpdate()
    {
        transform.RotateAround(planetTransform.position, direction, speed * multiplier * Time.deltaTime);
    }


}
