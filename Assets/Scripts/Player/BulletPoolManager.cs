using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : PoolManager<GameObject>
{
    private GameObject parents;
    public BulletPoolManager bulletPoolManager;
    public PlayerController playerController;
    public GunManager gunManager;
    public BulletPoolManager(GameObject parents, int maxSize, int minSize,
       PlayerController playerController,GunManager gunManager) : base(maxSize, minSize)
    {
        this.parents = parents;
        this.playerController = playerController;
        this.gunManager = gunManager;
    }

    public BulletPoolManager(int maxSize, int minSize) : base(maxSize, minSize){ }

    public override void Clear()
    {
        while (objectPool.Count > 0)
        {
            GameObject obj = objectPool.Dequeue();
            GameObject.Destroy(obj);
        }
        inUseObjects.Clear();
    }

    public override void EnPool(GameObject thing)
    {
        if (objectPool.Count > MaxSize)
        {
            // ������������������ٴ���Ķ�����׳��쳣
            GameObject.Destroy(thing);
            Debug.LogWarning("������");
            return;
        }
        thing.SetActive(false);
        objectPool.Enqueue(thing);
    }

    public override GameObject GetThingFromPool()
    {
        if (objectPool.Count == 0)
        {
            objectPool.Enqueue(GameObject.Instantiate<GameObject>(inUseObjects[0]));
        }

        GameObject thing = objectPool.Dequeue();
        inUseObjects.Add(thing);
        return thing;
    }

    public override void InitPool()
    {
        base.InitPool();
    }

    public override void InitPool(GameObject thing)
    {
        for (int i = 0; i < MaxSize; i++)
        {
            GameObject obj = GameObject.Instantiate<GameObject>(thing);
            obj.SetActive(false); // �մ���ʱ����Ϊ������״̬
            BulletManager bulletManager= obj.GetComponent<BulletManager>();
            bulletManager.Init(this.gunManager, this.playerController,this);
            if (parents != null) obj.transform.SetParent(parents.transform);
            objectPool.Enqueue(obj);
        }
    }

    public override void Recycle(GameObject thing)
    {
       
        thing.SetActive(false);
        thing.transform.SetParent(parents.transform);
        objectPool.Enqueue(thing);
        inUseObjects.Remove(thing);
    }
}
