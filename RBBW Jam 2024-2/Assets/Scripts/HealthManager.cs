using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int Counter = 0;
    public GameObject[] Hearts;
    public void removeHeart()
    {
        Hearts[Counter].SetActive(false);
        Counter++;
    }
}
