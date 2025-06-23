using System;

/// <summary>
/// 事件中心
/// </summary>
public class EventHandler
{
    /// <summary>
    /// 暂停游戏事件
    /// </summary>
    public static event Action PauseGameEvent;
    /// <summary>
    /// 暂停游戏
    /// </summary>
    public static void PauseGame() => PauseGameEvent?.Invoke();

    /// <summary>
    /// 恢复游戏事件
    /// </summary>
    public static event Action ResumeGameEvent;
    /// <summary>
    /// 恢复游戏
    /// </summary>
    public static void ResumeGame() => ResumeGameEvent?.Invoke();

    public static event Action<E_SkillType> UpdateSkillBarEvent;
    public static void UpdateSkillBar(E_SkillType type) => UpdateSkillBarEvent?.Invoke(type);

    public static event Action EndingGameEvent;
    public static void EndingGame() => EndingGameEvent?.Invoke();

    public static event Action PlayBubbleMusicEvent;
    public static void PlayBubbleMusic() => PlayBubbleMusicEvent?.Invoke();

    public static event Action PlayHurryMusicEvent;
    public static void PlayHurryMusic() => PlayHurryMusicEvent?.Invoke();

    public static event Action PlayBulletMusicEvent;
    public static void PlayBulletMusic() => PlayBulletMusicEvent?.Invoke();
}
