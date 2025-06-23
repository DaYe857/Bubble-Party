using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class BezierCurve
{
    public static Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        // ������α����������ϵĵ�
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return oneMinusT * oneMinusT * p0 + 2f * oneMinusT * t * p1 + t * t * p2;
    }

    public static Vector3 GetFirstDerivative(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        // ������α��������ߵ�һ�׵����������ߣ�
        return 2f * (1f - t) * (p1 - p0) + 2f * t * (p2 - p1);
    }
}


public class BallFusion : MonoBehaviour
{
    public Animator animator; // ����Animator���
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

        // ��ʼ�ں϶���
        animator.SetBool("isFusing", true);

        // ��ȡ����С���Transform���
        Transform thisTransform = transform;
        Transform otherTransform = otherBall.transform;

        // ���屴�������ߵĿ��Ƶ�
        Vector3 p0 = thisTransform.position;
        Vector3 p1 = (thisTransform.position + otherTransform.position) / 2f + Vector3.up * 0.5f; // �м��ƫ��һ��
        Vector3 p2 = otherTransform.position;
   

        // ʹ��Э����ģ���ر����������ƶ�
        yield return MoveAlongBezier(p0, p1, p2, 1.0f); // ����ʱ�������ƥ�䶯������

        // ������λ�ã�����С������ĵ㣩
        Vector3 newPosition = (thisTransform.position + p2) / 2f;

        // ���µ�ǰС���λ��
        thisTransform.position = newPosition;

        // ������һ��С��
        Destroy(otherBall);

        // �����ں϶���
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

