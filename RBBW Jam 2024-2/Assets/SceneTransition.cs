using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public void TransitionToScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
