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
            StartCoroutine(DestructionAsteroidCorutine());
        }
        else
        {
            Debug.Log("destroyParticle is null");
        }
    }

    private IEnumerator DestructionAsteroidCorutine()
    {
        modelAsteroid.SetActive(false);
        destroyParticle.gameObject.SetActive(true);
        yield return new WaitForSeconds(destroyParticle.main.duration);
        Destroy(gameObject);
    }
}
