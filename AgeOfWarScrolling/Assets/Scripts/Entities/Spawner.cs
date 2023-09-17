using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemiesToSpawn;
    public GameObject bonusPrefab;
    public float initialSpawnRate = 2.0f;
    public float spawnRateDecrease = 0.01f;
    public float minSpawnRate = 0.5f;
    public float minX = -2.0f;
    public float maxX = 2.0f;
    private float currentSpawnRate;
    private int spawnCounter = 0;
    public int bonusSpawnInterval = 10;

    void Start()
    {
        currentSpawnRate = initialSpawnRate;
        InvokeRepeating("SpawnObject", currentSpawnRate, currentSpawnRate);
    }

    void Update()
    {
        if (currentSpawnRate > minSpawnRate)
        {
            currentSpawnRate -= spawnRateDecrease * Time.deltaTime;
            currentSpawnRate = Mathf.Max(currentSpawnRate, minSpawnRate);
        }
    }

    void SpawnObject()
    {
        spawnCounter++;
        GameObject prefabToSpawn = (spawnCounter % bonusSpawnInterval == 0) ? bonusPrefab : enemiesToSpawn[Random.Range(0, enemiesToSpawn.Length)];
        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), transform.position.y, transform.position.z);
        GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

        Health healthComponent = spawnedObject.GetComponent<Health>();
        if (healthComponent != null)
        {
            healthComponent.GainHealth();
        }
    }
}