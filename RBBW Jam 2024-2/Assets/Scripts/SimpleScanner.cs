using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleScanner : MonoBehaviour
{
    Material mat;
    [SerializeField] float scanMaxRange;

    [SerializeField] AnimationCurve RevealCurve;
    [SerializeField] float revealDuration;
    [SerializeField] AnimationCurve StopCurve;
    [SerializeField] float stopDuration;

    private void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;
    }

    [ContextMenu("Start Scan")]
    public void StartScan()
    {
        StartCoroutine(SmoothReveal(RevealCurve, revealDuration, 100));
    }

    [ContextMenu("Stop Scan")]
    public void StopScan()
    {
        StartCoroutine(SmoothReveal(StopCurve, stopDuration, 100));
    }

    IEnumerator SmoothReveal(AnimationCurve curve, float duration, int steps)
    {
        float t = 0;
        float step = duration / steps;
        float currentValue;
        while (t < duration)
        {
            currentValue = curve.Evaluate(t / duration * curve.keys[curve.length - 1].time) * scanMaxRange;
            mat.SetFloat("_RevealRadius", currentValue);
            print(t);
            t += step;
            yield return new WaitForSeconds(step);
        }
    }


}
