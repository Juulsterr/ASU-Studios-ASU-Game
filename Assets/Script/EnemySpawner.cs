using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Transform player;

    [Header("Waves")]
    [SerializeField] private Wave[] waves;

    [Header("Next Level")]
    [SerializeField] private string nextLevelSceneName;

    private int currentWaveIndex = 0;
    private bool allWavesSpawned = false;

    private void Start()
    {
        // Automatisch speler zoeken als deze niet is ingevuld
        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

            if (playerObject != null)
            {
                player = playerObject.transform;
            }
            else
            {
                Debug.LogError("Geen Player gevonden! Geef de Player-tag aan je speler of sleep hem in het Player veld.");
                return;
            }
        }

        // Controleer elke seconde hoeveel enemies er nog leven
        InvokeRepeating(nameof(CheckEnemiesAlive), 1f, 1f);

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

        allWavesSpawned = true;

        Debug.Log("Alle waves zijn gespawned!");
    }

    private IEnumerator SpawnWave(Wave wave)
    {
        Debug.Log($"Wave {currentWaveIndex + 1} gestart!");

        for (int i = 0; i < wave.enemyCount; i++)
        {
            SpawnEnemy(wave);

            yield return new WaitForSeconds(wave.timeBetweenSpawns);
        }

        Debug.Log($"Wave {currentWaveIndex + 1} volledig gespawned!");
    }

    private void SpawnEnemy(Wave wave)
    {
        if (wave.enemyPrefabs == null || wave.enemyPrefabs.Length == 0)
        {
            Debug.LogWarning("Geen enemies toegevoegd aan deze wave.");
            return;
        }

        // Kies willekeurige enemy uit de lijst
        GameObject enemyPrefab =
            wave.enemyPrefabs[Random.Range(0, wave.enemyPrefabs.Length)];

        // Willekeurige hoek in een cirkel
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;

        // Willekeurige afstand van de speler
        float distance = Random.Range(
            wave.minSpawnDistance,
            wave.maxSpawnDistance
        );

        // Bereken spawnpositie rondom speler
        Vector3 spawnPosition =
            player.position +
            new Vector3(
                Mathf.Cos(angle) * distance,
                Mathf.Sin(angle) * distance,
                0f
            );

        Instantiate(
            enemyPrefab,
            spawnPosition,
            Quaternion.identity
        );
    }

    private void CheckEnemiesAlive()
    {
        // Alleen controleren als alle waves zijn gespawned
        if (!allWavesSpawned)
            return;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy1");

        if (enemies.Length == 0)
        {
            Debug.Log("Alle enemies verslagen! Volgende level laden...");

            CancelInvoke(nameof(CheckEnemiesAlive));

            SceneManager.LoadScene(nextLevelSceneName);
        }
    }
}

[System.Serializable]
public class Wave
{
    [Header("Enemies die mogen spawnen")]
    public GameObject[] enemyPrefabs;

    [Header("Aantal enemies")]
    public int enemyCount = 10;

    [Header("Wachttijd voor wave start")]
    public float startDelay = 10f;

    [Header("Tijd tussen enemies")]
    public float timeBetweenSpawns = 0.5f;

    [Header("Minimale spawn afstand")]
    public float minSpawnDistance = 5f;

    [Header("Maximale spawn afstand")]
    public float maxSpawnDistance = 10f;
}