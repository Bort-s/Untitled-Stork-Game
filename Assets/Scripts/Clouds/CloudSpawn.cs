using System.Diagnostics;
using System.Collections;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class CloudSpawn : MonoBehaviour
{
    public GameObject[] cloud;
    private float xAxisSpawn = 7f;
    private float spawnRangeY = 2f;
    private GameObject lastSpawnedCloud;

    private void Update()
    {
        if (GameData.gameCompleted) return;

        if (lastSpawnedCloud == null || (xAxisSpawn - lastSpawnedCloud.transform.position.x) >= GameDifficulty.distanceBetweenClouds)
        {
            SpawnCloud();
        }
    }

    private void SpawnCloud()
    {
        int randomCloud = Random.Range(0, cloud.Length);
        float randomY = Random.Range(-spawnRangeY, spawnRangeY);
        Vector3 spawnPos = new Vector3(xAxisSpawn, randomY, 0f);

        lastSpawnedCloud = Instantiate(cloud[randomCloud], spawnPos, Quaternion.identity);
    }
}
