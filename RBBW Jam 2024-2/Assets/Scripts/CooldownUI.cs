using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CooldownUI : MonoBehaviour
{
    [SerializeField] Slider GunCooldownSlider;
    [SerializeField] Slider ScannerCooldownSlider;
    [SerializeField] Slider RadarCooldownSlider;

    public void ResetCooldown(ToolSO tool)
    {
        switch (tool.name)
        {
            case "Gun":
                StartCoroutine(Cooldown(tool.cooldown, GunCooldownSlider));
                break;
            case "Scanner":
                StartCoroutine(Cooldown(tool.cooldown, ScannerCooldownSlider));
                break;
            case "Radar":
                StartCoroutine(Cooldown(tool.cooldown, RadarCooldownSlider));
                break;
        }
    }

    IEnumerator Cooldown(float duration, Slider slider)
    {
        slider.value = 1f;
        float step = duration / 100;
        float t = 0;
        while (t < duration)
        {
            t += step;
            slider.value -= step / duration;
            yield return new WaitForSeconds(step);
        }
    }
}
