using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class BezierCurve
{
    public static Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        // 计算二次贝塞尔曲线上的点
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return oneMinusT * oneMinusT * p0 + 2f * oneMinusT * t * p1 + t * t * p2;
    }

    public static Vector3 GetFirstDerivative(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        // 计算二次贝塞尔曲线的一阶导数（即切线）
        return 2f * (1f - t) * (p1 - p0) + 2f * t * (p2 - p1);
    }
}


public class BallFusion : MonoBehaviour
{
    public Animator animator; // 引用Animator组件
    private bool isFusing = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") && !isFusing)
        {
            StartCoroutine(FuseBalls(other.gameObject));
        }
    }

    private IEnumerator FuseBalls(GameObject otherBall)
    {
        isFusing = true;

        // 开始融合动画
        animator.SetBool("isFusing", true);

        // 获取两个小球的Transform组件
        Transform thisTransform = transform;
        Transform otherTransform = otherBall.transform;

        // 定义贝塞尔曲线的控制点
        Vector3 p0 = thisTransform.position;
        Vector3 p1 = (thisTransform.position + otherTransform.position) / 2f + Vector3.up * 0.5f; // 中间点偏移一点
        Vector3 p2 = otherTransform.position;
   

        // 使用协程来模拟沿贝塞尔曲线移动
        yield return MoveAlongBezier(p0, p1, p2, 1.0f); // 调整时间参数以匹配动画长度

        // 计算新位置（两个小球的中心点）
        Vector3 newPosition = (thisTransform.position + p2) / 2f;

        // 更新当前小球的位置
        thisTransform.position = newPosition;

        // 销毁另一个小球
        Destroy(otherBall);

        // 结束融合动画
        animator.SetBool("isFusing", false);
        isFusing = false;
    }

    private IEnumerator MoveAlongBezier(Vector3 p0, Vector3 p1, Vector3 p2, float duration)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            transform.position = BezierCurve.GetPoint(p0, p1, p2, t);
            yield return null;
        }
        transform.position = BezierCurve.GetPoint(p0, p1, p2, 1f);
    }

    
}

