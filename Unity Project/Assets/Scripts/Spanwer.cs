using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 3f;
    public float prefab3SpawnProbability = 0.2f;

    private void Start()
    {
        StartCoroutine(SpawnObjectAtRandomIntervals());
    }

    private IEnumerator SpawnObjectAtRandomIntervals()
    {
        while (true)
        {
            float randomInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(randomInterval);

            GameObject prefabToSpawn;
            float spawnChance = Random.Range(0f, 1f);

            if (spawnChance < prefab3SpawnProbability)
            {
                prefabToSpawn = prefab3;
            }
            else
            {
                prefabToSpawn = Random.Range(0f, 1f) > 0.5f ? prefab1 : prefab2;
            }

           GameObject go=Instantiate(prefabToSpawn, transform.position, transform.rotation);
           
        }
    }
}