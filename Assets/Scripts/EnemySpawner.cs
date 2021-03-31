using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float startSpawnRadius;
    private float spawnRadius;

    [HideInInspector]
    public Wave currentWave;
    private float nextSpawnTime = 1f;

    private void Update()
    {
        spawnRadius = startSpawnRadius;

        if(Time.time >= nextSpawnTime)
        {
            SpawnWave();
            nextSpawnTime = Time.time + 1f / currentWave.spawnRate;
        }
    }
    void SpawnWave()
    {
        foreach(EnemyType enemyType in currentWave.enemies)
        {
            if(Random.value <= enemyType.spawnChance)
            {
                SpawnEnemy(enemyType.enemyPrefab);
            }
        }
    }
    void SpawnEnemy(GameObject enemyPrefab)
    {
        Vector2 spawnPos = PlayerController.Position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
