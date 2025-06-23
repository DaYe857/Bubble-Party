using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ´ó¹ÇÍ·
/// </summary>
public class BigBone : MonoBehaviour
{
    [SerializeField]
    private float lifeTime = 5f;
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private bool isSkill;

    private Vector3 direction;
    private float tempTime = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerController>())
        {
            if(other.GetComponent<PlayerController>().playerType == E_PlayerType.purple)
            {
                EventHandler.UpdateSkillBar(E_SkillType.BigBone);
                direction = other.transform.forward;
                isSkill = true;
            }
        }

        if(other.CompareTag("ball")&&isSkill)
        {
            other.GetComponent<BubbleObject>().TurnRubbishObject();
        }
    }

    private void Update()
    {
        if (!isSkill) return;

        tempTime += Time.deltaTime;

        if(tempTime > lifeTime)
        {
            tempTime = 0;
            Destroy(gameObject);
        }

        transform.position += direction * speed * Time.deltaTime;
    }
}
