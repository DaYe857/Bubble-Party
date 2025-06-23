using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IPoolManager<T>
{

    T GetThingFromPool();//池中得到
    void EnPool(T thing);//入池
    void Clear();//清理
    void Recycle(T thing);//回收
    void InitPool();//初始化
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
            // 如果池中没有可用对象，则可以在此处创建新的对象并返回
            // 或者可以抛出异常或返回null，根据你的需求
            if (inUseObjects.Count > MaxSize)
                throw new System.Exception("池中无可用对象");
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
