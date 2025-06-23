using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float height;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target != null)
        {
            // ���������Ŀ��λ��
            Vector3 targetPosition = target.position;
            targetPosition.y += height;
            // ʹ��SmoothDamp��ƽ��������ƶ�
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
