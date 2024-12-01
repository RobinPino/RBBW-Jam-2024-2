using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarScanner : MonoBehaviour
{
    Material mat;

    private void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;
        if (GameManager.Instance.RadarOn) { StartScan(); }
    }

    [ContextMenu("Start Scan")]
    public void StartScan()
    {
        StartCoroutine(FadeIn());
    }

    [ContextMenu("Stop Scan")]
    public void StopScan()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        float currentOpacity = 1;
        while (currentOpacity > 0)
        {
            currentOpacity -= 0.05f;
            mat.SetFloat("_OpacityMaster", currentOpacity);
            yield return new WaitForSeconds(0.05f);
        }
        mat.SetInt("_IsScanning", 0);
    }

    IEnumerator FadeIn()
    {
        mat.SetInt("_IsScanning", 1);

        float currentOpacity = 0;
        while (currentOpacity < 1)
        {
            currentOpacity += 0.05f;
            mat.SetFloat("_OpacityMaster", currentOpacity);
            yield return new WaitForSeconds(0.05f);
        }

    }
}
