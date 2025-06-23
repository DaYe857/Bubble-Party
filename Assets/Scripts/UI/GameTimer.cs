using UnityEngine;
using System;
using UnityEngine.UI;

/// <summary>
/// 游戏计时器单例类，用于管理游戏中的时间。
/// </summary>
public class GameTimer : MonoSingleton<GameTimer>
{
    [Header("计时时长/秒")]
    public float gameTime;
    [Header("计时转换文本")]
    [SerializeField]
    private Text timelineText;
    private float currentTime = 0f; // 当前经过的时间
    private bool isRunning = false; // 计时器是否正在运行
    private float pauseTime = 0f;   // 暂停时的时间

    public event Action OnTimerStarted;       // 计时器开始事件
    public event Action OnTimerPaused;        // 计时器暂停事件
    public event Action OnTimerEnd;         // 计时器结束事件
    public event Action OnResume;  //恢复计时
    public string GameLeftTime => FormatTime(gameTime-currentTime);
    bool isPasued=false;
    bool isPlay = false;
    public AudioSource source;

    public void Start()
    {
        StartTimer();
    }

    /// <summary>
    /// 开始计时器。
    /// </summary>
    public void StartTimer()
    {
        isPasued = false;
        isRunning = true;
        OnTimerStarted?.Invoke();
    }
    /// <summary>
    /// 暂停计时器。
    /// </summary>
    public void PauseTimer()
    {
        isRunning = false;
        isPasued = true;
        pauseTime = currentTime;
        OnTimerPaused?.Invoke();
        
    }

    public void ResumeTimer()
    {
        if (isPasued)
        {
            isRunning = true;
            isPasued = false;
            currentTime = pauseTime;
            OnResume?.Invoke();
        }
    }

    private void end( )
    {   
        isPasued=false;
        isRunning = false;
        EventHandler.EndingGame();
        EventHandler.PauseGame();
        OnTimerEnd?.Invoke();
    }

    /// <summary>
    /// Unity生命周期方法，每帧调用一次。
    /// </summary>
    private void Update()
    {
        if (isRunning)
        {
            currentTime += Time.deltaTime;
        }
        else
        {
            if (isPasued)
            {
                PauseTimer();
            }
        }
        if((gameTime - currentTime) < 5f&&isPlay == false)
        {
            source.Play();
            isPlay = true;
        }
        if (currentTime > gameTime) 
        {
            end();
            currentTime = 0;
        }
        timelineText.text = GameLeftTime;
    }


    /// <summary>
    /// 将给定的时间（以秒为单位）格式化为“分:秒”形式。
    /// </summary>
    /// <param name="timeInSeconds">要格式化的时间，以秒为单位。</param>
    /// <returns>格式化后的时间字符串。</returns>
    private string FormatTime(float timeInSeconds)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeInSeconds);
        return string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
    }
}