using System.Collections;
using UnityEngine;

public class StorkSpawn : MonoBehaviour
{
    [SerializeField] private GameObject stork;
    private float xAxisSpawn = -7f;
    private int spawnRangeY = 3;
    [SerializeField] private float spawnTime = 0.5f;
    private bool inSpawn = false;
    private float lastSpawnLevel = 0f;
    private float spawnLevel;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        if (!inSpawn)
        {
            StartCoroutine(SpawnStork());
        }
    }

    private IEnumerator SpawnStork()
    {
        inSpawn = true;

        do
        {
            spawnLevel = Random.Range(-spawnRangeY, spawnRangeY);
        }
        while (spawnLevel == lastSpawnLevel);
        lastSpawnLevel = spawnLevel;
        float ySpawnValue = spawnLevel + Random.value;
        

        Vector3 spawnPos = new Vector3(xAxisSpawn, ySpawnValue, 0f);
        Instantiate(stork, spawnPos, Quaternion.identity);

        yield return new WaitForSeconds(spawnTime);
        inSpawn = false;
    }
}
