using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instacne;
    
    private void Awake()
    {
        if(instacne == null){ instacne = this; }
        else{ Destroy(gameObject); }
    }

    public int GetRubbishScore()
    {
        RubbishObject[] rubbishObjects = FindObjectsOfType<RubbishObject>();
        int rubbishScore = 0;
        foreach(var obj in rubbishObjects)
        {
            rubbishScore += obj.GetScore();
        }
        Debug.Log(rubbishScore);
        return rubbishScore;
    }

    public int GetBubbleScore()
    {
        BubbleObject[] bubbleObjects = FindObjectsOfType<BubbleObject>();
        int bubbleScore = 0;
        foreach(var obj in bubbleObjects)
        {
            bubbleScore += obj.GetBubbleHealth();
        }
        Debug.Log(bubbleScore);
        return bubbleScore;
    }
}
