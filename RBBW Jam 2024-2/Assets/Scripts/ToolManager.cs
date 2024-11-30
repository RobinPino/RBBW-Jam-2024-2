using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    public Tool currentTool;

    public List<Tool> toolList;

    [Serializable]
    public class Tool
    {
        public string name;
        public EventChannelSO ActivateEvent;
        public EventChannelSO DeactivateEvent;
        public float cooldown;
        public float lastUsedTimestamp = -100;
        public float activationTime;
    }
    private void Start()
    {
        currentTool = toolList[0];
    }

    public void SwitchTool(Tool tool)
    {
        if(currentTool == tool)
        {
            return;
        }
        if(Time.time - tool.lastUsedTimestamp < tool.cooldown)
        {
            print("On cooldown");
            return;
        }

        tool.lastUsedTimestamp = Time.time;
        currentTool.DeactivateEvent.Invoke(this);
        StartCoroutine(SwitchToTool(tool));        
    }

    IEnumerator SwitchToTool(Tool tool)
    {
        yield return new WaitForSeconds(tool.activationTime);
        tool.ActivateEvent.Invoke(this);
        currentTool = tool;
    }

    private void Update()
    {
        if (Input.GetKeyDown(Settings.ActivateGun)){
            SwitchTool(toolList[0]);
        }
        if (Input.GetKeyDown(Settings.ActivateRadar))
        {
            SwitchTool(toolList[1]);
        }
        if (Input.GetKeyDown(Settings.ActivateScan))
        {
            SwitchTool(toolList[2]);
        }
    }
}
