using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform planetTransform;

    private Vector3 direction;
    private int multiplier = 1;

    public Vector3 Direction { get { return direction; } set { direction = value; } }
    public int Multiplier { get { return multiplier;} set { multiplier = value; } }

    private void FixedUpdate()
    {
        transform.RotateAround(planetTransform.position, direction, speed * multiplier * Time.deltaTime);
    }


}
