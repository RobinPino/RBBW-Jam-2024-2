using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{
    public GameObject blackScreen;
    float blackAlpha = 255;
    int fadeSpeed = 2;
    bool waited = false;
    bool loading = false;
    bool StartScreen = false;
    public GameObject startscreenimage;

    public AudioSource introSound;

    private void Start()
    {
        StartCoroutine(waitForStartUp());
        StartCoroutine(waitAndLoadScene());
    }

    private void Update()
    {
        Color objectColor = blackScreen.GetComponent<Image>().color;
        Color startscreenColor = startscreenimage.GetComponent<Image>().color;
        if (waited && !loading)
        {
            if (blackScreen.GetComponent<Image>().color.a > 0)
            {
                blackAlpha = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, blackAlpha);
                blackScreen.GetComponent<Image>().color = objectColor;
            }

            else
            {
                Debug.Log("Loading!");
                StartCoroutine(loadGame());
            }
        }

        if (loading)
        {
            if (blackScreen.GetComponent<Image>().color.a < 1)
            {
                blackAlpha = objectColor.a + (fadeSpeed * Time.deltaTime);
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, blackAlpha);
                blackScreen.GetComponent<Image>().color = objectColor;
            }

            else
            {
                if (startscreenimage.GetComponent<Image>().color.a < 1)
                {
                    blackAlpha = startscreenColor.a + (fadeSpeed * Time.deltaTime);
                    startscreenColor = new Color(startscreenColor.r, startscreenColor.g, startscreenColor.b, blackAlpha);
                    startscreenimage.GetComponent<Image>().color = startscreenColor;
                }
                StartCoroutine(leaveScreenBlack());
            }
        }
    }

    IEnumerator waitAndLoadScene()
    {
        yield return new WaitForSeconds(5.2f);
        SceneManager.LoadScene(0);
    }

    IEnumerator waitForStartUp()
    {
        yield return new WaitForSeconds(1f);
        waited = true;
        introSound.Play();
        // play sound
    }

    IEnumerator loadGame()
    {
        yield return new WaitForSeconds(3f);
        loading = true;
    }

    IEnumerator leaveScreenBlack()
    {
        yield return new WaitForSeconds(2f);
        StartScreen = true;
    }
}
