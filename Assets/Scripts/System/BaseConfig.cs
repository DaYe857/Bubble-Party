/// <summary>
/// �ӵ�����
/// </summary>
public struct BulletType
{
    /// <summary>
    /// �����ӵ�
    /// </summary>
    public const string bubble = "bubblebullet";
    /// <summary>
    /// �����ӵ�
    /// </summary>
    public const string rubbish = "rubbishbullet";
}

/// <summary>
/// ���ȴ���
/// </summary>
public enum E_WindDirection
{
    /// <summary>
    /// ��X�ḺZ��
    /// </summary>
    nXnZ,
    /// <summary>
    /// ��X����Z��
    /// </summary>
    pXpZ,
    /// <summary>
    /// ��Z��
    /// </summary>
    pZ,
    /// <summary>
    /// ��Z��
    /// </summary>
    nZ
}

/// <summary>
/// �ܵ�����
/// </summary>
public enum E_PipleDirection
{
    /// <summary>
    /// ��X��
    /// </summary>
    nx,
    /// <summary>
    /// ��X��
    /// </summary>
    px
}

/// <summary>
/// ��������
/// </summary>
public enum E_SkillType
{
    /// <summary>
    /// ���ͷ
    /// </summary>
    BigBone,
    /// <summary>
    /// �����
    /// </summary>
    IceCream,
    /// <summary>
    /// �ȱ�
    /// </summary>
    Shell,
    /// <summary>
    /// ����
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