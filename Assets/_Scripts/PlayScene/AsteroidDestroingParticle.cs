using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestroingParticle : MonoBehaviour
{
    [Header("Particle Systems")]
    [SerializeField] private ParticleSystem destroyParticle;
    [SerializeField] private ParticleSystem fireTrailParticle;
    [Header("Models")]
    [SerializeField] private GameObject modelAsteroid;
    [SerializeField] private GameObject external3DModelAsteroid;
    [Header("Values")]
    [SerializeField] private float reductionModelScaleRate;
    [SerializeField] private float reductionParticleScaleRate;

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

    public void AsteroidDestroyOnPlanetShield()
    {
        if(fireTrailParticle != null)
        {
            StartCoroutine(DestructionAsteroidOnPLanetShieldCorutine());
            StartCoroutine(FireTrailParticleCoroutine());
        }
        else
        {
            Debug.Log("fireTrailParticle is null");
        }

    }

    private IEnumerator DestructionAsteroidOnPLanetShieldCorutine()
    {
        //var modelScale = modelAsteroid.transform.localScale;
        var fireTrailScale = fireTrailParticle.transform.localScale;
        var modelScale = external3DModelAsteroid.transform.localScale;
        while (external3DModelAsteroid.transform.localScale != Vector3.zero)
        {
            yield return new WaitForFixedUpdate();
            fireTrailScale = Vector3.Lerp(fireTrailScale, Vector3.zero, reductionParticleScaleRate * Time.deltaTime);
            modelScale = Vector3.Lerp(modelScale, Vector3.zero, reductionModelScaleRate * Time.deltaTime);
            //modelAsteroid.transform.localScale = modelScale;
            fireTrailParticle.transform.localScale = fireTrailScale;
            external3DModelAsteroid.transform.localScale = modelScale;
        }
        modelAsteroid.SetActive(false);
    }

    private IEnumerator FireTrailParticleCoroutine()
    {
        fireTrailParticle.gameObject.SetActive(true);
        yield return new WaitForSeconds(fireTrailParticle.main.duration);
        Destroy(gameObject);
    }
}
