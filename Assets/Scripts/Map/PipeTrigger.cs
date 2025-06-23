using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

/// <summary>
/// ˮ�ܴ�����
/// </summary>
public class PipeTrigger : MonoBehaviour
{
    [Header("����λ��")]
    [SerializeField]
    private Transform outPos;
    [Header("���ܷ���")]
    [SerializeField]
    private E_PipleDirection direction;
    [Header("׼���С")]
    [SerializeField]
    private int absorbHealth;

    ////�����
    //private ObjectPool<GameObject> pool;

    //private void Start()
    //{
    //    //��ȡ���ݶ����
    //    pool = BubbleObjectPool.instance.GetPool();
    //}

    private void OnTriggerEnter(Collider other)
    {
        //�ж��Ƿ�Ϊ����
        if(other.CompareTag("ball"))
        {
            //������ݵĴ�С����׼���С
            if(other.GetComponent<BubbleObject>().GetBubbleHealth() > absorbHealth)
            {
                BubbleGenerator.instance.GenerateBubble(other.GetComponent<BubbleObject>().GetBubbleHealth());
                BubbleObjectPool.instance.ReturnObject(other.gameObject);
                //�ͷ�����
                //pool.Release(other.gameObject);
                //��ʼ�ų�����
                StartCoroutine(OutBubble());
            }
        }
    }

    /// <summary>
    /// �ų�����
    /// </summary>
    /// <returns></returns>
    IEnumerator OutBubble()
    {
        //�ȴ�2��
        yield return new WaitForSeconds(2f);

        //�ӳ��л�ȡ����
        GameObject bubble = BubbleObjectPool.instance.GetObject();
        //��ʼ������λ�á�ָ���ƶ�����
        bubble.transform.position = outPos.position;
        bubble.transform.forward = outPos.forward;
        bubble.GetComponent<RandomMove>().MoveOut(100f, direction);
    }
}
