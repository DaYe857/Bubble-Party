using UnityEngine;

/// <summary>
/// 随机方向移动
/// </summary>
public class RandomMove : MonoBehaviour
{
    [Header("随机移动范围")]
    [Range(10f,50f)]
    [SerializeField]
    private float moveRange;
    
    //刚体组件
    private Rigidbody rb;

    //获取刚体组件
    private void Awake() => rb = GetComponent<Rigidbody>();

    private void OnEnable()
    {
        //添加暂停游戏事件
        EventHandler.PauseGameEvent += PauseMove;
        EventHandler.ResumeGameEvent += ResumeMove;
    }

    private void OnDisable()
    {
        //移除暂停游戏事件
        EventHandler.PauseGameEvent -= PauseMove;
        EventHandler.ResumeGameEvent -= ResumeMove;
    }

    public void ResetState()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    /// <summary>
    /// 开始移动
    /// </summary>
    private void Start() => Move();

    /// <summary>
    /// 用于出管道
    /// </summary>
    /// <param name="force">力的大小</param>
    /// <param name="direction">管道方向</param>
    public void MoveOut(float force, E_PipleDirection direction)
    {
        if (direction == E_PipleDirection.nx)
            rb.AddForce(new Vector3(-force, 0, 0));
        if (direction == E_PipleDirection.px)
            rb.AddForce(new Vector3(force, 0, 0));
    }

    /// <summary>
    /// 用于被风扇吹
    /// </summary>
    /// <param name="force">力的大小</param>
    /// <param name="direction">风扇方向</param>
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
    /// 暂停移动
    /// </summary>
    private void PauseMove() => rb.isKinematic = true;//设置刚体模拟动力学

    /// <summary>
    /// 恢复移动
    /// </summary>
    private void ResumeMove()
    {
        //设置刚体取消模拟动力学
        rb.isKinematic = false;
        //移动
        Move();
    }

    /// <summary>
    /// 朝随机方向移动
    /// </summary>
    private void Move()
    {
        //获取随机X向量值
        float randomForceX = Random.Range(-moveRange, moveRange);
        //获取随机Z向量值
        float randomForceZ = Random.Range(-moveRange, moveRange);
        //添加刚体受力
        rb.AddForce(new Vector3(randomForceX, 0f, randomForceZ));
    }
}