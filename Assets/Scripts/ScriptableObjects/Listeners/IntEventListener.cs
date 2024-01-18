using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
 
public class IntEventListener : MonoBehaviour
{
    [SerializeField] private IntEvent _event = default;

    public UnityEvent<int> listener;
    private void OnEnable()
    {
        _event?.Subscribe(Respond);
    }

    private void OnDisable()
    {
        _event?.Unsubscribe(Respond);
    }

    private void Respond(int value)
    {
        listener?.Invoke(value);
    }
}
