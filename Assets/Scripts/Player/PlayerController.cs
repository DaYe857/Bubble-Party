using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("������")]
    public E_PlayerType playerType;
    public float moveSpeed = 5.0f; // ��ɫ�ƶ��ٶ�
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float rotateSpeed = 200.0f; // ��ɫ��ת�ٶ�

    // ��������õİ���
    public KeyCode forwardKey = KeyCode.W;
    public KeyCode backwardKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    float moveHorizontal, moveVertical;
    bool isTriggerArea;
    private bool isPausing;


    private void OnEnable()
    {
        EventHandler.PauseGameEvent += PauseMove;
        EventHandler.ResumeGameEvent += ResumePause;
    }

    private void OnDisable()
    {
        EventHandler.PauseGameEvent -= PauseMove;
        EventHandler.ResumeGameEvent -= ResumePause;
    }

    private void PauseMove() => isPausing = true;

    private void ResumePause() => isPausing = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (isPausing) return;
        if (isTriggerArea) return;

        // ��ȡ���벢�����ƶ�����
        moveHorizontal = Input.GetKey(leftKey) ? -1 : (Input.GetKey(rightKey) ? 1 : 0);
        moveVertical = Input.GetKey(forwardKey) ? 1 : (Input.GetKey(backwardKey) ? -1 : 0);

        // �����ϼ������Ծ����Ƿ���Ҫ��ת
        if (Input.GetKey(forwardKey))
        {
            if (Input.GetKey(leftKey))
            {
                transform.Rotate(Vector3.up, -rotateSpeed * Time.deltaTime);
                moveHorizontal = 0; // ��ֹˮƽ�ƶ�����תͬʱ����
            }
            else if (Input.GetKey(rightKey))
            {
                transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
                moveHorizontal = 0; // ��ֹˮƽ�ƶ�����תͬʱ����
            }
        }

        // �����ƶ����򣨿����˿��ܵ���ת��
        Vector3 movement = transform.right * moveHorizontal + transform.forward * moveVertical;


        // �ƶ���ɫ
        controller.Move(movement * moveSpeed * Time.deltaTime);
        controller.Move(playerVelocity * Time.deltaTime);
        
    }

    public void triggerSpeedArea(Vector3 directo,float addSpeed,float addSpeedTime)
    {
        isTriggerArea = true;
        transform.forward = directo;
        StartCoroutine(SpeedBoostRoutine(directo.normalized, addSpeed+moveSpeed, addSpeedTime));
    }

    public void triggerDilverArea(Vector3 endPos)
    {   
        Debug.Log("ִ��");
        isTriggerArea = true;
        controller.enabled = false;
        transform.localPosition=endPos+new Vector3(2,0,2);
        controller.enabled = true;
        isTriggerArea =false;
    }

    public void triggerWindArea()
    {
        isTriggerArea = true;
    }

    private IEnumerator SpeedBoostRoutine(Vector3 direction, float speed, float duration)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            controller.Move( direction * speed * Time.deltaTime);
            yield return null;
        }
        isTriggerArea=false;
    }
}