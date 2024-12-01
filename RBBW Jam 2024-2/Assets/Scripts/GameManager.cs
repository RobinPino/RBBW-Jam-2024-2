using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool RadarOn;
    public bool ScannerOn;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void ToggleRadar(bool state)
    {
        RadarOn = state;
    }

    public void ToggleScanner(bool state)
    {
        ScannerOn = state;
    }
}
