using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private void Start()
    {
        Debug.Log(leftbottomCorner);
        Debug.Log(rightBottomCorner);
        initCornersFields();
        Debug.Log(leftbottomCorner);
        Debug.Log(rightBottomCorner);
    }
}
