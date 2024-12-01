using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextFlicker : MonoBehaviour
{
    TextMeshProUGUI text;
    [SerializeField] AnimationCurve curve;
    [SerializeField] float AnimationSpeed;
    private float startTime;
    bool flickering = false;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        Flicker();
    }

    private void Update()
    {
        if(flickering)
        {
            float time = (Time.time - startTime) * AnimationSpeed;
            float value = curve.Evaluate(time);
            text.color = new Color(text.color.r, text.color.g, text.color.b, value);
        }
    }

    [ContextMenu("Flicker")]
    public void Flicker()
    {
        text.enabled = true;
        startTime = Time.time;
        flickering = true;
    }
}
