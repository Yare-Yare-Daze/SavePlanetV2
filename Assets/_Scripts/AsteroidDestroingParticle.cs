using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestroingParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem destroyParticle;
    [SerializeField] private GameObject modelAsteroid;

    public void AsteroidDestroy()
    {
        if(destroyParticle != null)
        {
            destroyParticle.transform.position = modelAsteroid.transform.position;
            StartCoroutine(DestroyCorutine());
        }
        else
        {
            Debug.Log("destroyParticle is null");
        }
    }

    private IEnumerator DestroyCorutine()
    {
        modelAsteroid.SetActive(false);
        destroyParticle.gameObject.SetActive(true);
        yield return new WaitForSeconds(destroyParticle.main.duration);
        Destroy(gameObject);
    }
}
