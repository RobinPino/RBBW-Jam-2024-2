using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTime : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0f;
    }

    public void Unfreeze()
    {
        Time.timeScale = 1f;
    }
}
