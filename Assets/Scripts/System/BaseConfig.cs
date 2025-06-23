/// <summary>
/// 子弹种类
/// </summary>
public struct BulletType
{
    /// <summary>
    /// 泡泡子弹
    /// </summary>
    public const string bubble = "bubblebullet";
    /// <summary>
    /// 垃圾子弹
    /// </summary>
    public const string rubbish = "rubbishbullet";
}

/// <summary>
/// 风扇吹向
/// </summary>
public enum E_WindDirection
{
    /// <summary>
    /// 负X轴负Z轴
    /// </summary>
    nXnZ,
    /// <summary>
    /// 正X轴正Z轴
    /// </summary>
    pXpZ,
    /// <summary>
    /// 正Z轴
    /// </summary>
    pZ,
    /// <summary>
    /// 负Z轴
    /// </summary>
    nZ
}

/// <summary>
/// 管道方向
/// </summary>
public enum E_PipleDirection
{
    /// <summary>
    /// 负X轴
    /// </summary>
    nx,
    /// <summary>
    /// 正X轴
    /// </summary>
    px
}

/// <summary>
/// 技能种类
/// </summary>
public enum E_SkillType
{
    /// <summary>
    /// 大骨头
    /// </summary>
    BigBone,
    /// <summary>
    /// 冰淇淋
    /// </summary>
    IceCream,
    /// <summary>
    /// 扇贝
    /// </summary>
    Shell,
    /// <summary>
    /// 鸡蛋
    /// </summary>
    Egg
}

public enum E_PlayerType
{
    yellow,
    purple
}

public enum E_AirWallType
{
    nX,
    pX,
    nZ,
    pZ
}