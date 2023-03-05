using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangePlaceCloser : MonoBehaviour
{
    [SerializeField] private PlanetShield planetShield;
    [SerializeField] private float positionYCloser;

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
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - positionYCloser, transform.localPosition.z); ;
    }
}
