using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    GunManager gunManager;
    PlayerController playerController;
    CharacterController characterController;
    BulletPoolManager bulletPoolManager;
    public float moveSpeed;
    public float lifeTime;
    float timer = 0;

    void Update()
    {   
        
        if(characterController== null)characterController=GetComponent<CharacterController>();
        characterController.Move(transform.forward * moveSpeed*Time.deltaTime);

        timer+=Time.deltaTime;
       
        if (timer > lifeTime)
        {
           timer=0;
            OnLifeEnd();
        }
    }
    public void Init(GunManager gunManager,PlayerController playerController,BulletPoolManager bulletPoolManager)
    {
        this.gunManager = gunManager;
        this.playerController=playerController;
        this.bulletPoolManager=bulletPoolManager;   
    }
    public void OnEnable()
    {
        transform.SetParent(null);
        timer = 0;
    }

    public void OnLifeEnd()
    {
        bulletPoolManager.Recycle(this.gameObject);
    }
}