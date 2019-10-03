using System.Collections.Generic;
public class Observer<TData> : SingletonPure<Observer<TData>>
{
    public delegate void NotifyFunction(TData data);
    Dictionary<string, HashSet<NotifyFunction>> funcObserver = new Dictionary<string, HashSet<NotifyFunction>>();

    public void Add(string topic, NotifyFunction func)
    {
        GetListObserverForTopic(topic).Add(func);
    }

    public void Remove(string topic, NotifyFunction func)
    {
        GetListObserverForTopic(topic).Remove(func);
    }

    public void Notify(string topic, TData data)
    {
        var list = GetListObserverForTopic(topic);
        foreach(var func in list)
        {
            func(data);
        }
    }

    protected HashSet<NotifyFunction> GetListObserverForTopic(string topic)
    {
        if(!funcObserver.ContainsKey(topic))
        {
            funcObserver.Add(topic, new HashSet<NotifyFunction>());
        }
        return funcObserver[topic];
    }
}