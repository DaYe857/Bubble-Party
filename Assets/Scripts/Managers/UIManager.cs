using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject yellowWinPanel;
    [SerializeField]
    private GameObject purpleWinPanel;
    [SerializeField]
    private GameObject allWinPanel;

    private GameManager gm;

    private void Start()
    {
        gm = GameManager.instacne;
    }

    private void OnEnable()
    {
        EventHandler.EndingGameEvent += CompareScore;
    }

    private void OnDisable()
    {
        EventHandler.EndingGameEvent -= CompareScore;
    }

    private void CompareScore()
    {
        if(gm.GetBubbleScore()>gm.GetRubbishScore())
        { yellowWinPanel.SetActive(true); }

        if(gm.GetBubbleScore()<gm.GetRubbishScore())
        { purpleWinPanel.SetActive(true); }

        if(gm.GetBubbleScore() == gm.GetRubbishScore())
        { allWinPanel.SetActive(true); }
    }
}
