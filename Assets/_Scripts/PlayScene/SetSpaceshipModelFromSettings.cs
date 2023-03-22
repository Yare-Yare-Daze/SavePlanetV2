using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpaceshipModelFromSettings : MonoBehaviour
{
    [SerializeField] private Transform spaceshipsTransform;
    [SerializeField] private Transform spaceshipsLogicTransform;
    private List<Transform> spaceshipsList = new List<Transform>();
    private List<Transform> spaceshipsLogicList = new List<Transform>();

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        for (int i = 0; i < spaceshipsTransform.childCount; i++)
        {
            spaceshipsList.Add(spaceshipsTransform.GetChild(i));
            spaceshipsLogicList.Add(spaceshipsLogicTransform.GetChild(i));
            spaceshipsList[i].gameObject.SetActive(false);
            spaceshipsLogicList[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < spaceshipsTransform.childCount; i++)
        {
            if(i == PlayerPrefs.GetInt(Strings.SpaceshipKey))
            {
                spaceshipsList[i].gameObject.SetActive(true);
                spaceshipsLogicList[i].gameObject.SetActive(true);
            }
        }
    }
}
