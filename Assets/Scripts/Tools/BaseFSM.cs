using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    //进入状态时调用一次
    void OnEnter();
    //处于状态时，连续调用
    void OnUpdate();
    //退出状态时调用一次
    void OnExit();
    void TransitionReson();//判断状态转换原因
}

public class BaseFSM
{
    //一个状态生命周期的三个关键函数
    public IState currenState;
    //定义字典通过键值对建立状态与其对象的联系
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
        //同样在Update中调用每一种状态对应的OnUpdate
        // ChangeStateReson();
        currenState.OnUpdate();
    }
    /// <summary>
    /// 有限状态机状态切换函数
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
