using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject spawnObject;
    
    int i = 5;

    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            float randomX = Random.Range(5f, 5f);
            float randomY = Random.Range(10f, 8f);
            float randomZ = Random.Range(6f, 6f);

            Vector3 randomPos = new Vector3(randomX, randomY, randomZ);
            Instantiate(spawnObject, randomPos, Quaternion.identity);
        }
    }
}
