using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IMessageData
{

}
public class MessageData<T> : IMessageData//Message
{
    public UnityAction<T> MessageEvents;
    public MessageData(UnityAction<T> action)
    {
        MessageEvents += action;
    }
}
