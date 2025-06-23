using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCream : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerController>())
        {
            if(other.GetComponent<PlayerController>().playerType == E_PlayerType.purple)
            {
                EventHandler.UpdateSkillBar(E_SkillType.IceCream);
                EventHandler.PauseGame();
            }
        }
    }
}
