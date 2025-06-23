using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindForceArea : MonoBehaviour
{
    [SerializeField]
    private float windForce;
    [SerializeField]
    private E_WindDirection directionType;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ball"))
        {
            other.GetComponent<RandomMove>().ResetState();
            other.GetComponent<RandomMove>().MoveBack(windForce,directionType);
        }
    }
}
