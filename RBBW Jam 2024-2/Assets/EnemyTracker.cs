using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracker : MonoBehaviour
{
    public int ActiveEnemies = 0;
    Wavespawning waveSpawning;
    [SerializeField] GameObject WinScreen;

    private void Start()
    {
        waveSpawning = GetComponent<Wavespawning>();
    }

    public void EnemySpawned()
    {
        ActiveEnemies++;
        Debug.Log("Amount of active enemies: " + ActiveEnemies);
    }

    public void EnemyKilled()
    {
        ActiveEnemies--;
        Debug.Log("Amount of active enemies: " + ActiveEnemies);

        if (ActiveEnemies <= 0 && waveSpawning.wavesSpawned >= waveSpawning.waves.Count)
        {
            print("All enemies are kill");
            WinScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
