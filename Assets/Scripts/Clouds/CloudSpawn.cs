using System.Diagnostics;
using System.Collections;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class CloudSpawn : MonoBehaviour
{
    public GameObject[] cloud;
    private float xAxisSpawn = 6.5f;
    private float spawnTime = 1.4f;
    private float spawnRangeY = 3f;
    private bool spawn = true;
    private void Start()
    {
        
    }

    private void Update()
    {
        if (spawn)
        {
            spawn = false;
            StartCoroutine(SpawnCloud());
        }
    }

    private IEnumerator SpawnCloud()
    {
        int randomCloud = Random.Range(0, 4);
        float randomY = Random.Range(-spawnRangeY, spawnRangeY);
        Vector3 spawnPos = new Vector3(xAxisSpawn, randomY, 0f);
        Instantiate(cloud[randomCloud], spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(spawnTime / GameData.speed);
        spawn = true;
    }
}
