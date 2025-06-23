using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

/// <summary>
/// �����ںϹ�����
/// </summary>
public class BallMergeManager : MonoBehaviour
{
    /// <summary>
    /// �����ں�
    /// </summary>
    public bool isBussioning { get; set; }
    /// <summary>
    /// �����ں�
    /// </summary>
    public bool isNeedBussion { get; set; }

    [Header("�ں��ٶ�")]
    [SerializeField]
    private float shrinkSpeed;

    private int id;
    //0 ��� 1 ��С
    private int type;
    //�ߴ��С
    private Vector3 targetSize;

    //private ObjectPool<GameObject> pool;

    private void OnEnable()
    {
        //����״̬
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
            // �����Žӽ���ʱֹͣ��С�����ٶ���
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

            // �����Žӽ���ʱֹͣ��С�����ٶ���
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