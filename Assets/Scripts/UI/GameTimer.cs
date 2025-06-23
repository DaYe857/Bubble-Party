using UnityEngine;
using System;
using UnityEngine.UI;

/// <summary>
/// ��Ϸ��ʱ�������࣬���ڹ�����Ϸ�е�ʱ�䡣
/// </summary>
public class GameTimer : MonoSingleton<GameTimer>
{
    [Header("��ʱʱ��/��")]
    public float gameTime;
    [Header("��ʱת���ı�")]
    [SerializeField]
    private Text timelineText;
    private float currentTime = 0f; // ��ǰ������ʱ��
    private bool isRunning = false; // ��ʱ���Ƿ���������
    private float pauseTime = 0f;   // ��ͣʱ��ʱ��

    public event Action OnTimerStarted;       // ��ʱ����ʼ�¼�
    public event Action OnTimerPaused;        // ��ʱ����ͣ�¼�
    public event Action OnTimerEnd;         // ��ʱ�������¼�
    public event Action OnResume;  //�ָ���ʱ
    public string GameLeftTime => FormatTime(gameTime-currentTime);
    bool isPasued=false;
    bool isPlay = false;
    public AudioSource source;

    public void Start()
    {
        StartTimer();
    }

    /// <summary>
    /// ��ʼ��ʱ����
    /// </summary>
    public void StartTimer()
    {
        isPasued = false;
        isRunning = true;
        OnTimerStarted?.Invoke();
    }
    /// <summary>
    /// ��ͣ��ʱ����
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
    /// Unity�������ڷ�����ÿ֡����һ�Ρ�
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
    /// ��������ʱ�䣨����Ϊ��λ����ʽ��Ϊ����:�롱��ʽ��
    /// </summary>
    /// <param name="timeInSeconds">Ҫ��ʽ����ʱ�䣬����Ϊ��λ��</param>
    /// <returns>��ʽ�����ʱ���ַ�����</returns>
    private string FormatTime(float timeInSeconds)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeInSeconds);
        return string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
    }
}