using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceshipsChanger : MonoBehaviour
{
    [SerializeField] private GameObject spaceshipsGO;
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;

    private List<GameObject> spaceships = new List<GameObject>();
    private int currentSpaceshipIndex;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        for (int i = 0; i < spaceshipsGO.transform.childCount; i++)
        {
            spaceships.Add(spaceshipsGO.transform.GetChild(i).gameObject);
        }

        if(!PlayerPrefs.HasKey(Strings.SpaceshipKey))
        {
            currentSpaceshipIndex = 0;
            PlayerPrefs.SetInt(Strings.SpaceshipKey, currentSpaceshipIndex);
        }
        else
        {
            currentSpaceshipIndex = PlayerPrefs.GetInt(Strings.SpaceshipKey);
        }

        leftButton.onClick.AddListener(OnClickLeftButtonHandler);
        rightButton.onClick.AddListener(OnClickRightButtonHandler);

        leftButton.onClick.AddListener(OnClickAnyButtonHandler);
        rightButton.onClick.AddListener(OnClickAnyButtonHandler);
    }

    private void OnClickLeftButtonHandler()
    {
        currentSpaceshipIndex = Mathf.Clamp(currentSpaceshipIndex + 1, 0, spaceships.Count - 1);
        PlayerPrefs.SetInt(Strings.SpaceshipKey, currentSpaceshipIndex);
    }

    private void OnClickRightButtonHandler()
    {
        currentSpaceshipIndex = Mathf.Clamp(currentSpaceshipIndex - 1, 0, spaceships.Count - 1);
        PlayerPrefs.SetInt(Strings.SpaceshipKey, currentSpaceshipIndex);
    }

    private void OnClickAnyButtonHandler()
    {
        for (int i = 0; i < spaceships.Count; i++)
        {
            spaceships[i].SetActive(false);
        }
        spaceships[currentSpaceshipIndex].SetActive(true);
    }
}
