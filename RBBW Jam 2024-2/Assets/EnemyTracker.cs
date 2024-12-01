using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracker : MonoBehaviour
{
    public int ActiveEnemies = 0;
    public bool CanEnd = false;

    public void EnemySpawned()
    {
        ActiveEnemies++;
        CanEnd = false;
        Debug.Log("Amount of active enemies: " + ActiveEnemies);
    }

    public void EnemyKilled()
    {
        ActiveEnemies--;
        CanEnd = true;
        Debug.Log("Amount of active enemies: " + ActiveEnemies);

        if (ActiveEnemies == 0 && CanEnd)
        {
            NextWave();
        }
    }

    public void NextWave()
    {
        Debug.Log("Wave completed, starting next wave");
    }
}
