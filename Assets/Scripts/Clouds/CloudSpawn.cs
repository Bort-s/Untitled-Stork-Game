using UnityEngine;

public class CloudSpawn : MonoBehaviour
{
    public GameObject cloud;
    private float xAxisSpawn = 6.5f;
    private float spawnTime = 1f;
    private float spawnRangeY = 3f;




    private void Start()
    {
        InvokeRepeating(nameof(SpawnCloud), 0f, spawnTime);
    }

    private void Update()
    {
        
    }

    private void SpawnCloud()
    {
        float randomY = Random.Range(-spawnRangeY, spawnRangeY);
        Vector3 spawnPos = new Vector3(xAxisSpawn, randomY, 0f);
        Instantiate(cloud, spawnPos, Quaternion.identity);
    }
}
