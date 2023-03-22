using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipLogic2 : MonoBehaviour
{
    [SerializeField] private CircleCollider2D playerShieldCollider;
    [SerializeField] private Light playerShieldLightEffect;

    [SerializeField] private float shieldColliderValue = 0.6f;
    [SerializeField] private float shieldLightValue = 1.3f;

    private void Start()
    {
        playerShieldCollider.radius = shieldColliderValue;
        playerShieldLightEffect.range = shieldLightValue;
    }
}
