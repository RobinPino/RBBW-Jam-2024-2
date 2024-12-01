using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Wavespawning : MonoBehaviour
{
    public List<WaveSO> waves;
    public GameObject enemy;
    [SerializeField] float radius;
    [SerializeField] float timeBetweenWaves;
    [SerializeField] int wavesSpawned = 0;


    private void FixedUpdate()
    {
        if (Time.time % timeBetweenWaves == 0 && wavesSpawned<waves.Count)
        {
            SpawnWave(waves[wavesSpawned]);
            wavesSpawned += 1;
        }
    }
    private void SpawnWave(WaveSO wave)
    {
        StartCoroutine(a(wave));

    }

    IEnumerator a(WaveSO wave)
    {
        Dictionary<Shape, int> remainingEnemies = new Dictionary<Shape, int>();
        for (int index = 0; index < wave.enemyTypes.Count; index++)
        {
            Shape curType = wave.enemyTypes[index];
            int curnr = wave.enemynrs[index];
            remainingEnemies[curType] = curnr;

        }
        for (int enemiesLeftToSpawn = remainingEnemies.Values.Sum(); enemiesLeftToSpawn > 0; enemiesLeftToSpawn--)
        {
            int enemyIndex = UnityEngine.Random.Range(0, enemiesLeftToSpawn);
            yield return new WaitForSeconds(wave.spawnDelay);
            SpawnEnemy(GetShapeFromDict(remainingEnemies, enemyIndex));

        }
    }

    private void SpawnEnemy(Shape shape)
    {
        float direction = UnityEngine.Random.value * 2 * Mathf.PI;
        Vector3 spawnLocation = new Vector3(radius * Mathf.Cos(direction), radius * Mathf.Sin(direction), 0);
        GameObject currentEntity = Instantiate(enemy, spawnLocation, Quaternion.identity);
        currentEntity.GetComponent<ShapeBehaviour>().shape = shape;

    }
    private Shape GetShapeFromDict(Dictionary<Shape, int>dict, int dictindex)
    {
        int currentIndex = 0;

        foreach (var kvp in dict)
        {
            currentIndex += kvp.Value;
            if (dictindex < currentIndex)
            {
                return kvp.Key;
            }
        }

        throw new ArgumentOutOfRangeException(nameof(dictindex), "Index exceeds the range of the expanded dictionary.");
    }

}
