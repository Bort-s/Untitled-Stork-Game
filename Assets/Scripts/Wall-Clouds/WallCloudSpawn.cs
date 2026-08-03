using System.Diagnostics;
using System.Collections;
using UnityEngine;
using Debug = UnityEngine.Debug;
using System.Runtime.CompilerServices;


public class WallCloudSpawn : MonoBehaviour
{
    public GameObject[] wallCloud;
    private float xAxisSpawn = 7f;
    private float yAxisSpawn = -2.89f;

    public bool isUp;

    private float decreaseF = 0.3f;

    private GameObject lastSpawnedCloud;
    private float lastCloudWidth = 0f;

    void Start()
    {
        if (isUp)
            yAxisSpawn = 2.89f;
    }

    void Update()
    {
        if (GameData.gameCompleted)
        {
            if (isUp)
            {
                yAxisSpawn += Time.deltaTime * decreaseF;
            }
            else
            {
                yAxisSpawn -= Time.deltaTime * decreaseF;
            }
        }

        if (yAxisSpawn > 4 || yAxisSpawn < -4)
            return;

        if (lastSpawnedCloud == null || (xAxisSpawn - lastSpawnedCloud.transform.position.x) >= lastCloudWidth)
        {
            SpawnWallCloud();
        }
    }

    private void SpawnWallCloud()
    {
        int randomWallCloud = Random.Range(0, wallCloud.Length); 
        
        float spawnX;

        if (lastSpawnedCloud == null)
        {
            spawnX = xAxisSpawn;
        }
        else
        {
            spawnX = lastSpawnedCloud.transform.position.x + lastCloudWidth;
        }

        Vector3 spawnPos = new Vector3(spawnX, yAxisSpawn, 0f);
        
        lastSpawnedCloud = Instantiate(wallCloud[randomWallCloud], spawnPos, Quaternion.identity);
        
        if (isUp)
        {
            lastSpawnedCloud.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        
        SpriteRenderer sr = lastSpawnedCloud.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            lastCloudWidth = sr.bounds.size.x;
        }
    }
}