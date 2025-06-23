using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

/// <summary>
/// 泡泡对象
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
    /// 变成垃圾对象
    /// </summary>
    public void TurnRubbishObject()
    {
        //获取随机垃圾对象
        RubbishObject obj = RubbishGenerator.instance.GetRubbishObject();
        //生成随机垃圾对象在当前位置
        Instantiate(obj.gameObject, transform.position,Quaternion.identity);
        EventHandler.PlayBubbleMusic();
        //BubbleGenerator.instance.GenerateBubble(bubbleHealth);
        BubbleObjectPool.instance.ReturnObject(gameObject);
    }

    /// <summary>
    /// 重置状态
    /// </summary>
    /// <param name="pos">坐标位置</param>
    public void ResetState(Vector3 pos)
    {
        transform.position = pos;
        transform.localScale = Vector3.one;
    }
    //public void SetTransform(Vector3 pos) => transform.position = pos; 

    /// <summary>
    /// 设置泡泡生命值
    /// </summary>
    /// <param name="health"></param>
    public void SetBubbleHeath(int health) => bubbleHealth = health;

    /// <summary>
    /// 获取泡泡生命值
    /// </summary>
    /// <returns></returns>
    public int GetBubbleHealth() => bubbleHealth;
    /// <summary>
    /// 泡泡融合
    /// </summary>
    public void AddBubbleHealth()
    {
        bubbleHealth++;
    }
    /// <summary>
    /// 减少泡泡
    /// </summary>
    private void ReduceBubbleHealth()
    {
        bubbleHealth--;
        if(bubbleHealth == 0){ TurnRubbishObject();return; }
        BubbleObjectPool.instance.Spawn();
    }
}
