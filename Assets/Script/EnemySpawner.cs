using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Transform player;

    [Header("Waves")]
    [SerializeField] private Wave[] waves;

    private int currentWaveIndex = 0;

    private void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player niet toegewezen!");
            return;
        }

        StartCoroutine(StartWaves());
    }

    private IEnumerator StartWaves()
    {
        while (currentWaveIndex < waves.Length)
        {
            Wave wave = waves[currentWaveIndex];

            Debug.Log($"Wave {currentWaveIndex + 1} start over {wave.startDelay} seconden");

            yield return new WaitForSeconds(wave.startDelay);

            yield return StartCoroutine(SpawnWave(wave));

            currentWaveIndex++;
        }

        Debug.Log("Alle waves voltooid!");
    }

    private IEnumerator SpawnWave(Wave wave)
    {
        Debug.Log($"Wave {currentWaveIndex + 1} gestart!");

        for (int i = 0; i < wave.enemyCount; i++)
        {
            SpawnEnemy(wave);

            yield return new WaitForSeconds(wave.timeBetweenSpawns);
        }

        Debug.Log($"Wave {currentWaveIndex + 1} voltooid!");
    }

    private void SpawnEnemy(Wave wave)
    {
        if (wave.enemyPrefabs.Length == 0)
            return;

        // Kies random enemy
        GameObject enemyPrefab =
            wave.enemyPrefabs[Random.Range(0, wave.enemyPrefabs.Length)];

        // Random richting rondom speler
        Vector2 direction = Random.insideUnitCircle.normalized;

        // Random afstand
        float distance =
            Random.Range(wave.minSpawnDistance, wave.maxSpawnDistance);

        // Spawn positie
        Vector3 spawnPosition =
            player.position +
            new Vector3(
                direction.x * distance,
                0f,
                direction.y * distance
            );

        Instantiate(
            enemyPrefab,
            spawnPosition,
            Quaternion.identity
        );
    }
}

[System.Serializable]
public class Wave
{
    [Header("Enemies die mogen spawnen")]
    public GameObject[] enemyPrefabs;

    [Header("Aantal enemies in deze wave")]
    public int enemyCount = 10;

    [Header("Wachttijd voor deze wave start")]
    public float startDelay = 10f;

    [Header("Tijd tussen spawns")]
    public float timeBetweenSpawns = 0.5f;

    [Header("Spawn afstand vanaf speler")]
    public float minSpawnDistance = 5f;

    public float maxSpawnDistance = 10f;
}