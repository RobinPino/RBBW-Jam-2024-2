using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int Counter = 0;
    public GameObject[] Hearts;
    [SerializeField] Sprite deadHeartSprite;
    [SerializeField] Sprite fullHeartSprite;

    private void Awake()
    {
        foreach (GameObject heart in Hearts)
        {
            heart.GetComponent<Image>().sprite = fullHeartSprite;
        }
    }

    public void removeHeart()
    {
        Hearts[Counter].GetComponent<Image>().sprite = deadHeartSprite;
        Counter++;
    }
}
