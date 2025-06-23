using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public GameObject bulletPrefab; // �ӵ�Ԥ�Ƽ�
    public Transform shootPos;      // ���λ��
    private BulletPoolManager bulletPoolManager;
    public KeyCode shootKeyCode;    // �������
    public float shootInterval;    //������
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
        // ��ʼ���ӵ��ع�����
        bulletPoolManager = new BulletPoolManager(this.gameObject, 50, 100, GetComponentInParent<PlayerController>(), this);

        bulletPoolManager.InitPool(bulletPrefab);

        // ���ó�ʼ�´����ʱ��Ϊ��ǰʱ��
        
    }

    void Update()
    {
        if (isPausing) return;
        if(Input.GetKeyDown(shootKeyCode))
        {
            isShoot = !isShoot;
        }
        // ����Ƿ���������������Ƿ��˿��������ʱ��
        if (Input.GetKeyDown(shootKeyCode)&&timer >= shootInterval)
        {
            Shoot();
            MusicManager.instance.PlayBulletMusic();
            // ������һ�����ʱ��
            timer = 0;
            
        }
        timer += Time.deltaTime;
    }

    void Shoot()
    {
        // ���ӵ����л�ȡ�ӵ�
        GameObject bullet = bulletPoolManager.GetThingFromPool();
        if (bullet != null)
        {
            bullet.transform.position = shootPos.position;
            bullet.transform.rotation = shootPos.rotation;
            bullet.SetActive(true);
        }
    }
}