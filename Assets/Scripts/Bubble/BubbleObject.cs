using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

/// <summary>
/// ���ݶ���
/// </summary>
public class BubbleObject : MonoBehaviour
{
    [SerializeField]
    private int bubbleHealth = 1;

    //private Queue<GameObject> pool;

    //private void Start()
    //{
    //    pool = BubbleObjectPool.instance.GetPool();
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(BulletType.rubbish))
        {
            other.GetComponent<BulletManager>().OnLifeEnd();
            ReduceBubbleHealth();
        }
    }

    /// <summary>
    /// �����������
    /// </summary>
    public void TurnRubbishObject()
    {
        //��ȡ�����������
        RubbishObject obj = RubbishGenerator.instance.GetRubbishObject();
        //����������������ڵ�ǰλ��
        Instantiate(obj.gameObject, transform.position,Quaternion.identity);
        EventHandler.PlayBubbleMusic();
        //BubbleGenerator.instance.GenerateBubble(bubbleHealth);
        BubbleObjectPool.instance.ReturnObject(gameObject);
    }

    /// <summary>
    /// ����״̬
    /// </summary>
    /// <param name="pos">����λ��</param>
    public void ResetState(Vector3 pos)
    {
        transform.position = pos;
        transform.localScale = Vector3.one;
    }
    //public void SetTransform(Vector3 pos) => transform.position = pos; 

    /// <summary>
    /// ������������ֵ
    /// </summary>
    /// <param name="health"></param>
    public void SetBubbleHeath(int health) => bubbleHealth = health;

    /// <summary>
    /// ��ȡ��������ֵ
    /// </summary>
    /// <returns></returns>
    public int GetBubbleHealth() => bubbleHealth;
    /// <summary>
    /// �����ں�
    /// </summary>
    public void AddBubbleHealth()
    {
        bubbleHealth++;
    }
    /// <summary>
    /// ��������
    /// </summary>
    private void ReduceBubbleHealth()
    {
        bubbleHealth--;
        if(bubbleHealth == 0){ TurnRubbishObject();return; }
        BubbleObjectPool.instance.Spawn();
    }
}
