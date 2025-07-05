using UnityEngine;

public class cactusSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject cactusPrefab;

    [SerializeField]
    float spawnRate = 2f;
    [SerializeField]
    float minY = -1;
    [SerializeField]
    float maxX = 1f;

    private float timeSinceLastSpawn;

    // Update is called once per frame
    void Update()
    {
        //  生成のタイミングを管理
        timeSinceLastSpawn += Time.deltaTime;

        if(timeSinceLastSpawn >= spawnRate)
        {
            SpawnCactus();
            timeSinceLastSpawn = 0;
        }
    }

    void SpawnCactus()
    {

        float randomX = Random.Range(minY,maxX);
        Instantiate(cactusPrefab,new Vector2(randomX,-2f), Quaternion.identity);
    }
}
