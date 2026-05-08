using System.Diagnostics;
using System.Collections;
using UnityEngine;
using Debug = UnityEngine.Debug;
using System.Runtime.CompilerServices;


public class WallCloudSpawn : MonoBehaviour
{
    public GameObject[] wallCloud;
    private float xAxisSpawn = 7f;
    public float yAxisSpawn;
    private float spawnTime = 0.3f;
    private bool spawn = true;

    public bool isUp;

    private void Update()
    {
        if (spawn)
        {
            spawn = false;
            StartCoroutine(SpawnWallCloud());
        }
    }

    private IEnumerator SpawnWallCloud()
    {
        int randomWallCloud = Random.Range(0, 8);
        Vector3 spawnPos = new Vector3(xAxisSpawn, yAxisSpawn, 0f);
        GameObject spawnedCloud = Instantiate(wallCloud[randomWallCloud], spawnPos, Quaternion.identity);
        if (isUp)
        {
            spawnedCloud.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        yield return new WaitForSeconds(spawnTime / GameData.speed);
        spawn = true;
    }
}