using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
 
public class VoidEventListener : MonoBehaviour
{
    [SerializeField] private VoidEvent _event = default;

    public UnityEvent listener;
    private void OnEnable()
    {
        _event?.Subscribe(Respond);
    }

    private void OnDisable()
    {
        _event?.Unsubscribe(Respond);
    }

    private void Respond()
    {
        listener?.Invoke();
    }
}
