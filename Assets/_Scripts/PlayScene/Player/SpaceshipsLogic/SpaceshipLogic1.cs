using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipLogic1 : MonoBehaviour
{
    [SerializeField] private PlayerMove playerMove;
    [SerializeField] private float boostSpeedModifier = 1.3f;

    private void Start()
    {
        playerMove.Speed = playerMove.Speed * boostSpeedModifier;
    }
}
