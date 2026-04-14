using System.Runtime.CompilerServices;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject PipePrefab;
    private readonly float SpawnTime = 4f;
    private readonly float minY = -1f;
    private readonly float maxY = 3f;
    private readonly float SpawnX = 5f;
    private float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = Time.deltaTime + SpawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        // pipe Spawner
        timer += Time.deltaTime;
        if (timer >= SpawnTime)
        {
            float randomY = Random.Range(minY, maxY);
            Vector2 spawnPositon = new(SpawnX, randomY);
            Instantiate(PipePrefab, spawnPositon, Quaternion.identity);

            // Reset timer
            timer = 0f;
        }
    }
}
