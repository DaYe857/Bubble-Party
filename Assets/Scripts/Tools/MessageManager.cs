using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MessageManager : Singleton<MessageManager>//Manager
{
    private Dictionary<string, IMessageData> dictionaryMessage;//存储消息信息
    public MessageManager()
    {
        InitData();
    }
    private void InitData()
    {
        dictionaryMessage = new Dictionary<string, IMessageData>();
    }
    public void Register<T>(string key, UnityAction<T> action)//注册消息
    {
        if (dictionaryMessage.TryGetValue(key, out var previousAction))
        {
            if (previousAction is MessageData<T> messageData)
            {
                messageData.MessageEvents += action;
            }
        }
        else
        {
            dictionaryMessage.Add(key, new MessageData<T>(action));
        }
    }
    public void Remove<T>(string key, UnityAction<T> action)//删除消息
    {
        if (dictionaryMessage.TryGetValue(key, out var previousAction))
        {
            if (previousAction is MessageData<T>)
            {
                (previousAction as MessageData<T>).MessageEvents -= action;
            }
        }
    }
    public void Run<T>(string key, T data)//执行
    {
        if (dictionaryMessage.TryGetValue(key, out var previousAction))
        {
            (previousAction as MessageData<T>)?.MessageEvents(data);
        }
    }
    public void Clear()
    {
        dictionaryMessage.Clear();
    }
}