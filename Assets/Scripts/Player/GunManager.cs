using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public GameObject bulletPrefab; // 子弹预制件
    public Transform shootPos;      // 射击位置
    private BulletPoolManager bulletPoolManager;
    public KeyCode shootKeyCode;    // 射击按键
    public float shootInterval;    //射击间隔
    private float timer = 0;
    private bool isShoot;
    private bool isPausing;

    private void OnEnable()
    {
        EventHandler.PauseGameEvent += PauseShooting;
        EventHandler.ResumeGameEvent += ResumeShooting;
    }

    private void OnDisable()
    {
        EventHandler.PauseGameEvent -= PauseShooting;
        EventHandler.PauseGameEvent -= ResumeShooting;
    }

    private void PauseShooting() => isPausing = true;

    private void ResumeShooting() => isPausing = false;
    void Start()
    {
        // 初始化子弹池管理器
        bulletPoolManager = new BulletPoolManager(this.gameObject, 50, 100, GetComponentInParent<PlayerController>(), this);

        bulletPoolManager.InitPool(bulletPrefab);

        // 设置初始下次射击时间为当前时间
        
    }

    void Update()
    {
        if (isPausing) return;
        if(Input.GetKeyDown(shootKeyCode))
        {
            isShoot = !isShoot;
        }
        // 检查是否按下了射击键并且是否到了可以射击的时间
        if (Input.GetKeyDown(shootKeyCode)&&timer >= shootInterval)
        {
            Shoot();
            MusicManager.instance.PlayBulletMusic();
            // 计算下一次射击时间
            timer = 0;
            
        }
        timer += Time.deltaTime;
    }

    void Shoot()
    {
        // 从子弹池中获取子弹
        GameObject bullet = bulletPoolManager.GetThingFromPool();
        if (bullet != null)
        {
            bullet.transform.position = shootPos.position;
            bullet.transform.rotation = shootPos.rotation;
            bullet.SetActive(true);
        }
    }
}