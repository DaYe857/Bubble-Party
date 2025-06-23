using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

/// <summary>
/// 泡泡对象池
/// </summary>
public class BubbleObjectPool : MonoBehaviour
{
    public static BubbleObjectPool instance;
    [SerializeField]
    private Transform targetHeight;
    [Range(0,50)]
    [Header("生成范围")]
    [SerializeField]
    private float spawnRange;
    [Header("对象物体")]
    [SerializeField]
    private GameObject targetObj;
    [Header("生成对象数量")]
    [SerializeField]
    private int objectNum;

    [Header("总对象数量")]
    [SerializeField]
    private int sumCount;
    [Header("激活物体数量")]
    [SerializeField]
    private int activeCount;
    [Header("隐藏物体数量")]
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
    /// 初始化创建对象
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
    /// 获取对象
    /// </summary>
    /// <param name="obj"></param>
    //private void actionOnGet(GameObject obj)
    //{
    //    obj.gameObject.SetActive(true);
    //    obj.GetComponent<BubbleObject>().SetBubbleHeath(1);
    //}

    /// <summary>
    /// 回收对象
    /// </summary>
    /// <param name="obj"></param>
    //private void actionOnRelease(GameObject obj)
    //{
    //    obj.gameObject.SetActive(false);
    //}

    /// <summary>
    /// 对象销毁
    /// </summary>
    /// <param name="obj"></param>
    //private void actionOnDestroy(GameObject obj)
    //{
    //    Destroy(obj);
    //}

    /// <summary>
    /// 获取对象池
    /// </summary>
    /// <returns></returns>
    public Queue<GameObject> GetPool() => pooledObjects;

    /// <summary>
    /// 生成对象
    /// </summary>
    public void Spawn()
    {
        GameObject temp = InitObject();
        temp.transform.position = new Vector3(Random.Range(-spawnRange, spawnRange), targetHeight.position.y, Random.Range(-spawnRange, spawnRange));
        temp.transform.localScale = Vector3.one;
        Debug.Log(pooledObjects.Count);
    }
}
