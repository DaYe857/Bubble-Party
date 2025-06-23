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
            // 计算相机的目标位置
            Vector3 targetPosition = target.position;
            targetPosition.y += height;
            // 使用SmoothDamp来平滑相机的移动
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
