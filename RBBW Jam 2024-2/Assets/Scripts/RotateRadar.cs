using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRadar : MonoBehaviour
{
    [SerializeField]Material mat;
    float rotateSpeed;

    private void Start()
    {
        rotateSpeed = mat.GetFloat("_RotateSpeed");
    }

    private void Update()
    {
        float rot = (Shader.GetGlobalVector("_Time").y * rotateSpeed) % 1;
        //print(rot);
        transform.rotation = Quaternion.Euler(0, 0, -rot * 360);
    }
}
