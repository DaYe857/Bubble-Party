using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirWall : MonoBehaviour
{
    public E_AirWallType type;
    [SerializeField]
    private float backForce;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ball"))
        {
            other.GetComponent<RandomMove>().ResetState();
            if(!CompareTag("wall"))
            other.GetComponent<RandomMove>().MoveBack(backForce,type);
        }
    }
}
