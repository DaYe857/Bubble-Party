using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IPoolManager<T>
{

    T GetThingFromPool();//���еõ�
    void EnPool(T thing);//���
    void Clear();//����
    void Recycle(T thing);//����
    void InitPool();//��ʼ��
    void InitPool(T thing);
}
public class PoolManager<T> : IPoolManager<T>
{
    protected Queue<T> objectPool;
    protected List<T> inUseObjects;

    public PoolManager(int maxSize, int minSize)
    {
        MaxSize = maxSize;
        MinSize = minSize;
        objectPool = new Queue<T>();
        inUseObjects = new List<T>();
    }
    public PoolManager()
    {

        objectPool = new Queue<T>();
        inUseObjects = new List<T>();
    }
    protected int MaxSize { get; set; }
    protected int MinSize { get; set; }
    public virtual void Clear()
    {
        while (objectPool.Count > 0)
        {
            T obj = objectPool.Dequeue();
        }
        inUseObjects.Clear();
    }

    public virtual void EnPool(T thing)
    {

    }

    public virtual T GetThingFromPool()
    {
        if (objectPool.Count == 0)
        {
            // �������û�п��ö���������ڴ˴������µĶ��󲢷���
            // ���߿����׳��쳣�򷵻�null�������������
            if (inUseObjects.Count > MaxSize)
                throw new System.Exception("�����޿��ö���");
            return default(T);
        }
        T thing = objectPool.Dequeue();
        inUseObjects.Add(thing);
        return thing;
    }

    public virtual void InitPool()
    {

    }

    public virtual void Recycle(T thing)
    {

    }
    public virtual void InitPool(T thing)
    {

    }

}
