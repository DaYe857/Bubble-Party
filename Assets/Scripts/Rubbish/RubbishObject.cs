using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class RubbishObject : MonoBehaviour
{
    [SerializeField]
    private int score;
    //private ObjectPool<GameObject> pool;

    private void Awake()
    {
        transform.position = new Vector3(transform.position.x, 4.818756f, transform.position.z);
    }

    //private void Start()
    //{
    //    pool = BubbleObjectPool.instance.GetPool();
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(BulletType.bubble))
        {
            other.GetComponent<BulletManager>().OnLifeEnd();
            TurnBubbleObject();
        }
    }

    public void TurnBubbleObject()
    {
        GameObject obj = BubbleObjectPool.instance.GetObject();
        obj.GetComponent<BubbleObject>().ResetState(transform.position);


        Destroy(gameObject);
    }

    //public void SetPool(ObjectPool<GameObject> pool) => this.pool = pool;
    public int GetScore() => score;
}
