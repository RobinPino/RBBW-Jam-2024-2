using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    [SerializeField]List<string> Levels = new List<string>();
    [SerializeField] TextMeshProUGUI LevelText;
    int currentLevel = 1;

    private void Start()
    {
        currentLevel = 1;
        LevelText.text = currentLevel.ToString();
    }

    public void ChangeLevelSelected(int change)
    {
        currentLevel += change;
        currentLevel = Mathf.Clamp(currentLevel, 1, Levels.Count);
        LevelText.text = currentLevel.ToString();
    }

    public void LoadLevel()
    {
        if (currentLevel <= Levels.Count)
        {
            print("Load level: " + Levels[currentLevel - 1]);
            UnityEngine.SceneManagement.SceneManager.LoadScene(Levels[currentLevel - 1]);
        }
    }
}
