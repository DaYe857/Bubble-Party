using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

/// <summary>
/// 水管触发器
/// </summary>
public class PipeTrigger : MonoBehaviour
{
    [Header("出管位置")]
    [SerializeField]
    private Transform outPos;
    [Header("出管方向")]
    [SerializeField]
    private E_PipleDirection direction;
    [Header("准入大小")]
    [SerializeField]
    private int absorbHealth;

    ////对象池
    //private ObjectPool<GameObject> pool;

    //private void Start()
    //{
    //    //获取泡泡对象池
    //    pool = BubbleObjectPool.instance.GetPool();
    //}

    private void OnTriggerEnter(Collider other)
    {
        //判断是否为泡泡
        if(other.CompareTag("ball"))
        {
            //如果泡泡的大小大于准入大小
            if(other.GetComponent<BubbleObject>().GetBubbleHealth() > absorbHealth)
            {
                BubbleGenerator.instance.GenerateBubble(other.GetComponent<BubbleObject>().GetBubbleHealth());
                BubbleObjectPool.instance.ReturnObject(other.gameObject);
                //释放泡泡
                //pool.Release(other.gameObject);
                //开始排出泡泡
                StartCoroutine(OutBubble());
            }
        }
    }

    /// <summary>
    /// 排出泡泡
    /// </summary>
    /// <returns></returns>
    IEnumerator OutBubble()
    {
        //等待2秒
        yield return new WaitForSeconds(2f);

        //从池中获取泡泡
        GameObject bubble = BubbleObjectPool.instance.GetObject();
        //初始化泡泡位置、指向、移动方向
        bubble.transform.position = outPos.position;
        bubble.transform.forward = outPos.forward;
        bubble.GetComponent<RandomMove>().MoveOut(100f, direction);
    }
}
