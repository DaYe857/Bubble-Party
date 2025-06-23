using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleGenerator : MonoBehaviour
{
    public static BubbleGenerator instance;

    private void Awake()
    {
        if(instance == null){ instance = this; }
        else{ Destroy(gameObject); }
    }

    public void GenerateBubble(int count)
    {
        if(count > 1)
        {
            for (int i = 0; i < count - 1; i++)
            {
                BubbleObjectPool.instance.Spawn();
            }
        }

    }
}
