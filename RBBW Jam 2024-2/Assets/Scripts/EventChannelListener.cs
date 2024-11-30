using UnityEngine;
using UnityEngine.Events;

public class EventChannelListener : MonoBehaviour
{
    public EventChannelSO Event;
    public UnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventInvoked()
    {
        Response.Invoke();
    }
}