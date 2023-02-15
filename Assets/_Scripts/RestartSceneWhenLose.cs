using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartSceneWhenLose : MonoBehaviour
{
    [SerializeField] private PlanetGroundAsteroidCollide planetGroundAsteroidCollide;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        planetGroundAsteroidCollide.OnPlanetDestroy += RestartScene;
    }

    private void OnDisable()
    {
        planetGroundAsteroidCollide.OnPlanetDestroy -= RestartScene;
    }

    private void RestartScene()
    {
        StartCoroutine(WaitTouchToRestartCoroutine());
    }

    private IEnumerator WaitTouchToRestartCoroutine()
    {
        yield return new WaitUntil(() => Input.touchCount > 0);
        SceneManager.LoadScene(0);
    }
}
