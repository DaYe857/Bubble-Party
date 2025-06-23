using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

/// <summary>
/// 泡泡融合管理器
/// </summary>
public class BallMergeManager : MonoBehaviour
{
    /// <summary>
    /// 正在融合
    /// </summary>
    public bool isBussioning { get; set; }
    /// <summary>
    /// 可以融合
    /// </summary>
    public bool isNeedBussion { get; set; }

    [Header("融合速度")]
    [SerializeField]
    private float shrinkSpeed;

    private int id;
    //0 变大 1 缩小
    private int type;
    //尺寸大小
    private Vector3 targetSize;

    //private ObjectPool<GameObject> pool;

    private void OnEnable()
    {
        //重置状态
        isBussioning = false;
        isNeedBussion = true;
        type = -1;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ball")
        {
            BallMergeManager otherBallMergeManager = other.gameObject.GetComponent<BallMergeManager>();
            if (otherBallMergeManager.isBussioning||!otherBallMergeManager.isNeedBussion||isBussioning||!isNeedBussion) return;
            if (gameObject.transform.localScale.x > other.gameObject.transform.localScale.x)
            {
                GetComponent<BubbleObject>().AddBubbleHealth();
                turnBiggerOrSmaller(0, other.transform.localScale + transform.localScale);
                otherBallMergeManager.turnBiggerOrSmaller(1, Vector3.zero);
            }
            else
            {
                if (id > otherBallMergeManager.id)
                {
                    GetComponent<BubbleObject>().AddBubbleHealth();
                    turnBiggerOrSmaller(0, other.transform.localScale + transform.localScale);
                    otherBallMergeManager.turnBiggerOrSmaller(1, Vector3.zero);
                }
            }

        }
    }

    public void turnBiggerOrSmaller(int type, Vector3 size)
    {
        if (isBussioning) return;
        this.type = type;
        targetSize = size;
        isBussioning = true;
    }

    //private void Start()
    //{
    //    pool = BubbleObjectPool.instance.GetPool();
    //}

    public void FixedUpdate()
    {
        if (type == -1) return;
        isBussioning = true;
        if (type == 0)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetSize, Time.deltaTime * shrinkSpeed);
            if (targetSize.x >= 5)
            {
                isNeedBussion = false;
                targetSize = new Vector3(5, 5, 5);
            }
            // 当缩放接近零时停止缩小并销毁对象
            if ((targetSize - transform.localScale).magnitude < 0.1f)
            {   

                isBussioning = false;
                type = -1;
                transform.localScale = targetSize;

            }
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetSize, Time.deltaTime * shrinkSpeed);

            // 当缩放接近零时停止缩小并销毁对象
            if (transform.localScale.magnitude < 0.1f)
            {
                isBussioning = false;
                transform.localScale = targetSize;
                BubbleObjectPool.instance.ReturnObject(gameObject);
            }
        }
    }

    public void SetID(int id) => this.id = id;
}