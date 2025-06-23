using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    //����״̬ʱ����һ��
    void OnEnter();
    //����״̬ʱ����������
    void OnUpdate();
    //�˳�״̬ʱ����һ��
    void OnExit();
    void TransitionReson();//�ж�״̬ת��ԭ��
}

public class BaseFSM
{
    //һ��״̬�������ڵ������ؼ�����
    public IState currenState;
    //�����ֵ�ͨ����ֵ�Խ���״̬����������ϵ
    private Dictionary<string, IState> states = new Dictionary<string, IState>();
    public virtual void Init() { }
    public void AddState(string state_Enum, IState state)
    {
        if (states.ContainsKey(state_Enum)) return;
        states.Add(state_Enum, state);
    }
    public void DeleteState(string state_Enum)
    {
        if (!states.ContainsKey(state_Enum)) return;
        states.Remove(state_Enum);
    }
    public void Update()
    {
        //ͬ����Update�е���ÿһ��״̬��Ӧ��OnUpdate
        // ChangeStateReson();
        currenState.OnUpdate();
    }
    /// <summary>
    /// ����״̬��״̬�л�����
    /// </summary>
    /// <param name="type"></param>
    public void TransitionState(string type)
    {
        if (currenState != null)
        {
            currenState.OnExit();
        }
        currenState = states[type];
        currenState.OnEnter();
    }
}
