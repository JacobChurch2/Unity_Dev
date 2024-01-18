using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/GameObject Event")]
public class GameObjectEvent : ScriptableObjectBase
{
    public UnityAction<GameObject> onEventRaised;

    public void RaiseEvent(GameObject value)
    {
        onEventRaised?.Invoke(value);
    }

    public void Subscribe(UnityAction<GameObject> function)
    {
        onEventRaised += function;
    }

    public void Unsubscribe(UnityAction<GameObject> function)
    {
        onEventRaised -= function;
    }
}
