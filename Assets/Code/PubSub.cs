using System;
using System.Collections.Generic;

public static class PubSub
{
    static Dictionary<Type,List<Action<PubSubMessage>>> subscriptions = new Dictionary<Type,List<Action<PubSubMessage>>>();

    public static void Publish(PubSubMessage message)
    {
        if(subscriptions.ContainsKey(message.GetType()))
        {
            List<Action<PubSubMessage>> subs = subscriptions[message.GetType()];
            for(int i = subs.Count - 1;  i >= 0; i--)
            {
                subs[i].Invoke(message);
            }
        }
    }

    public static void Subscribe(PubSubMessage message, Action<PubSubMessage> callback)
    {
        Type t = message.GetType();
        if(!subscriptions.ContainsKey(t)) subscriptions[t] = new List<Action<PubSubMessage>>();
        subscriptions[t].Add(callback);
    }
}

public abstract class PubSubMessage
{

}