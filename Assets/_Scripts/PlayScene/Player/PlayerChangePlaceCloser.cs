using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangePlaceCloser : MonoBehaviour
{
    [SerializeField] private PlanetShield planetShield;
    [SerializeField] private float closeOffsetValue = 0.25f;

    private void Awake()
    {
        Initilaize();
    }

    private void Initilaize()
    {
        planetShield.OnShieldDeactivated += ChangePositionCloser;
    }

    private void OnDisable()
    {
        planetShield.OnShieldDeactivated -= ChangePositionCloser;
    }

    private void ChangePositionCloser()
    {
        var targetOffset = (transform.position - planetShield.transform.position) * closeOffsetValue;

        transform.position -= targetOffset;
    }
}
