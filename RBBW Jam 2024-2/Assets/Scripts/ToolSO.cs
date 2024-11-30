using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tool", menuName = "Tool")]
public class ToolSO : ScriptableObject
{
    public EventChannelSO ActivateEvent;
    public EventChannelSO DeactivateEvent;
    public float cooldown;
    public float lastUsedTimestamp = -100;
    public float activationTime;
}
