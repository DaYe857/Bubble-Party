using UnityEngine;

/// <summary>
/// ��������ƶ�
/// </summary>
public class RandomMove : MonoBehaviour
{
    [Header("����ƶ���Χ")]
    [Range(10f,50f)]
    [SerializeField]
    private float moveRange;
    
    //�������
    private Rigidbody rb;

    //��ȡ�������
    private void Awake() => rb = GetComponent<Rigidbody>();

    private void OnEnable()
    {
        //�����ͣ��Ϸ�¼�
        EventHandler.PauseGameEvent += PauseMove;
        EventHandler.ResumeGameEvent += ResumeMove;
    }

    private void OnDisable()
    {
        //�Ƴ���ͣ��Ϸ�¼�
        EventHandler.PauseGameEvent -= PauseMove;
        EventHandler.ResumeGameEvent -= ResumeMove;
    }

    public void ResetState()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    /// <summary>
    /// ��ʼ�ƶ�
    /// </summary>
    private void Start() => Move();

    /// <summary>
    /// ���ڳ��ܵ�
    /// </summary>
    /// <param name="force">���Ĵ�С</param>
    /// <param name="direction">�ܵ�����</param>
    public void MoveOut(float force, E_PipleDirection direction)
    {
        if (direction == E_PipleDirection.nx)
            rb.AddForce(new Vector3(-force, 0, 0));
        if (direction == E_PipleDirection.px)
            rb.AddForce(new Vector3(force, 0, 0));
    }

    /// <summary>
    /// ���ڱ����ȴ�
    /// </summary>
    /// <param name="force">���Ĵ�С</param>
    /// <param name="direction">���ȷ���</param>
    public void MoveBack(float force, E_WindDirection direction)
    {
        switch (direction)
        {
            case E_WindDirection.pXpZ:
                rb.AddForce(new Vector3(force, 0f, force));
                break;
            case E_WindDirection.nXnZ:
                rb.AddForce(new Vector3(-force, 0f, -force));
                break;
            case E_WindDirection.pZ:
                rb.AddForce(new Vector3(0, 0, force));
                break;
            case E_WindDirection.nZ:
                rb.AddForce(new Vector3(0, 0, -force));
                break;
        }
    }

    public void MoveBack(float force,E_AirWallType type)
    {
        switch(type)
        {
            case E_AirWallType.nX:
                rb.AddForce(new Vector3(-force, 0f, 0f));
                break;
            case E_AirWallType.pX:
                rb.AddForce(new Vector3(force, 0f, 0f));
                break;
            case E_AirWallType.nZ:
                rb.AddForce(new Vector3(0f, 0f, -force));
                break;
            case E_AirWallType.pZ:
                rb.AddForce(new Vector3(0f, 0f, force));
            break;
        }
    }

    /// <summary>
    /// ��ͣ�ƶ�
    /// </summary>
    private void PauseMove() => rb.isKinematic = true;//���ø���ģ�⶯��ѧ

    /// <summary>
    /// �ָ��ƶ�
    /// </summary>
    private void ResumeMove()
    {
        //���ø���ȡ��ģ�⶯��ѧ
        rb.isKinematic = false;
        //�ƶ�
        Move();
    }

    /// <summary>
    /// ����������ƶ�
    /// </summary>
    private void Move()
    {
        //��ȡ���X����ֵ
        float randomForceX = Random.Range(-moveRange, moveRange);
        //��ȡ���Z����ֵ
        float randomForceZ = Random.Range(-moveRange, moveRange);
        //��Ӹ�������
        rb.AddForce(new Vector3(randomForceX, 0f, randomForceZ));
    }
}