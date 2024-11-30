using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventChannel", menuName = "Events/Event Channel", order = 1)]
public class EventChannelSO : ScriptableObject
{
    private List<EventChannelListener> gameEventListeners = new List<EventChannelListener>();
    [SerializeField] private bool LogInvokes;

    public void Invoke(Object invoker)
    {
        if (LogInvokes)
        {
            Debug.Log(this.name + " was invoked by " + invoker);
        }
       
        for (int i = gameEventListeners.Count - 1; i >= 0; i--)
        {
            gameEventListeners[i].OnEventInvoked();
        }
    }

    public void RegisterListener(EventChannelListener listener)
    {
        Utils.TryAdd(gameEventListeners, listener);
    }

    public void UnregisterListener(EventChannelListener listener)
    {
        Utils.TryRemove(gameEventListeners, listener);
    }
}

#if UNITY_EDITOR
[UnityEditor.CustomEditor(typeof(EventChannelSO))]
public class EventChannelSOEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EventChannelSO eventChannel = target as EventChannelSO;

        if (GUILayout.Button("Invoke"))
        {
            eventChannel.Invoke(this);
        }
    }
}
#endif