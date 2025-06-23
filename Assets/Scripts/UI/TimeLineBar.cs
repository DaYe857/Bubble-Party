using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLineBar : MonoBehaviour
{
    [SerializeField]
    private Text timelineText;

    private void FixedUpdate()
    {
        timelineText.text = GameTimer.Instance.GameLeftTime;
    }
}