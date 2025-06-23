using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

/// <summary>
/// ���ݶ����
/// </summary>
public class BubbleObjectPool : MonoBehaviour
{
    public static BubbleObjectPool instance;
    [SerializeField]
    private Transform targetHeight;
    [Range(0,50)]
    [Header("���ɷ�Χ")]
    [SerializeField]
    private float spawnRange;
    [Header("��������")]
    [SerializeField]
    private GameObject targetObj;
    [Header("���ɶ�������")]
    [SerializeField]
    private int objectNum;

    [Header("�ܶ�������")]
    [SerializeField]
    private int sumCount;
    [Header("������������")]
    [SerializeField]
    private int activeCount;
    [Header("������������")]
    [SerializeField]
    private int inactiveCount;

    private Queue<GameObject> pooledObjects;

    //private ObjectPool<GameObject> pool;

    private static int ID = 0;

    private void Awake()
    {
        if(instance == null){ instance = this; }
        else{ Destroy(gameObject); }

        pooledObjects = new Queue<GameObject>();
        //pool = new ObjectPool<GameObject>
        //(createFunc,actionOnGet,actionOnRelease,actionOnDestroy,true,10,objectNum);

        for (int i = 0; i < objectNum; i++) { Spawn(); }
    }

    public GameObject InitObject()
    {
        GameObject newObj = Instantiate(targetObj);
        newObj.GetComponent<BallMergeManager>().SetID(ID);
        ID++;
        return newObj;
    }

    public GameObject GetObject()
    {
        if (pooledObjects.Count > 0)
        {
            GameObject obj = pooledObjects.Dequeue();
            obj.SetActive(true);
            obj.GetComponent<BubbleObject>().SetBubbleHeath(1);
            return obj;
        }
        else
        {
            GameObject newObj = Instantiate(targetObj);
            newObj.GetComponent<BallMergeManager>().SetID(ID);
            ID++;
            return newObj;
        }
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        pooledObjects.Enqueue(obj);
    }

    private void Update()
    {
        //sumCount = pool.CountAll;
        //activeCount = pool.CountActive;
        //inactiveCount = pool.CountInactive;
    }

    /// <summary>
    /// ��ʼ����������
    /// </summary>
    /// <returns></returns>
    //private GameObject createFunc()
    //{
    //    var obj = Instantiate(targetObj, transform);
    //    obj.GetComponent<BallMergeManager>().SetID(ID);

    //    ID++;

    //    return obj;
    //}

    /// <summary>
    /// ��ȡ����
    /// </summary>
    /// <param name="obj"></param>
    //private void actionOnGet(GameObject obj)
    //{
    //    obj.gameObject.SetActive(true);
    //    obj.GetComponent<BubbleObject>().SetBubbleHeath(1);
    //}

    /// <summary>
    /// ���ն���
    /// </summary>
    /// <param name="obj"></param>
    //private void actionOnRelease(GameObject obj)
    //{
    //    obj.gameObject.SetActive(false);
    //}

    /// <summary>
    /// ��������
    /// </summary>
    /// <param name="obj"></param>
    //private void actionOnDestroy(GameObject obj)
    //{
    //    Destroy(obj);
    //}

    /// <summary>
    /// ��ȡ�����
    /// </summary>
    /// <returns></returns>
    public Queue<GameObject> GetPool() => pooledObjects;

    /// <summary>
    /// ���ɶ���
    /// </summary>
    public void Spawn()
    {
        GameObject temp = InitObject();
        temp.transform.position = new Vector3(Random.Range(-spawnRange, spawnRange), targetHeight.position.y, Random.Range(-spawnRange, spawnRange));
        temp.transform.localScale = Vector3.one;
        Debug.Log(pooledObjects.Count);
    }
}
