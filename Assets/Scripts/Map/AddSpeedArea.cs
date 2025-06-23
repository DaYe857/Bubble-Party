using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpeedArea : MonoBehaviour
{
    public Vector3 speedDir;
    public float addSpeed;
    public float speedTime;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().triggerSpeedArea(speedDir, addSpeed,speedTime);
            EventHandler.PlayHurryMusic();
        }
    }
}
