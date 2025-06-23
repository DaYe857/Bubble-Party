using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    [SerializeField]
    private AudioSource sounFx;
    [SerializeField]
    private AudioSource bubbleMusic;
    [SerializeField]
    private AudioSource hurryMusic;
    [SerializeField]
    private AudioSource bulletMusic;

    private void OnEnable()
    {
        EventHandler.PlayBubbleMusicEvent += PlayBubbleMusic;
        EventHandler.PlayHurryMusicEvent += PlayHurryMusic;
        EventHandler.PlayBubbleMusicEvent += PlayBulletMusic;
    }

    private void OnDisable()
    {
        EventHandler.PlayBubbleMusicEvent -= PlayBubbleMusic;
        EventHandler.PlayHurryMusicEvent -= PlayHurryMusic;
        EventHandler.PlayBulletMusicEvent -= PlayBulletMusic;
    }

    private void Awake()
    {
        if(instance == null){ instance = this; }
        else { Destroy(gameObject); }
    }

    public void PlaySoundFx() => sounFx.Play();

    public void PlayBubbleMusic() => bubbleMusic.Play();

    public void PlayHurryMusic() => hurryMusic.Play();

    public void PlayBulletMusic() => bulletMusic.Play();
}
