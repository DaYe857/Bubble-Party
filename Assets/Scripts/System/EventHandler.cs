using System;

/// <summary>
/// �¼�����
/// </summary>
public class EventHandler
{
    /// <summary>
    /// ��ͣ��Ϸ�¼�
    /// </summary>
    public static event Action PauseGameEvent;
    /// <summary>
    /// ��ͣ��Ϸ
    /// </summary>
    public static void PauseGame() => PauseGameEvent?.Invoke();

    /// <summary>
    /// �ָ���Ϸ�¼�
    /// </summary>
    public static event Action ResumeGameEvent;
    /// <summary>
    /// �ָ���Ϸ
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
