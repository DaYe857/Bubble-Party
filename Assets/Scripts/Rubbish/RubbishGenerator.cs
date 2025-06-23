using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishGenerator : MonoBehaviour
{
    public static RubbishGenerator instance;
    [SerializeField]
    private RubbishObject[] rubbishObjects;

    private int rubbishCount;

    private void Awake()
    {
        if(instance == null){ instance = this; }
        else{ Destroy(gameObject); }

        rubbishCount = rubbishObjects.Length;
    }

    public RubbishObject GetRubbishObject()
    {
        return rubbishObjects[Random.Range(0, rubbishCount)];
    }
}
