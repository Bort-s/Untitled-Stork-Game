using System.Diagnostics;
using System.Collections;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class CloudsMenu : MonoBehaviour
{
    public GameObject[] cloud;
    private float xAxisSpawn = 7f;
    private float spawnTime = 0.5f;
    private float spawnRangeY = 2.8f;
    private bool spawn = true;

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
        int randomCloud = Random.Range(0, cloud.Length);
        float randomY = Random.Range(-spawnRangeY, spawnRangeY);
        Vector3 spawnPos = new Vector3(xAxisSpawn, randomY, 0f);
        Instantiate(cloud[randomCloud], spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(spawnTime);
        spawn = true;
    }
}
