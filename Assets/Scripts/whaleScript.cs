using UnityEngine;

public class whaleScript : MonoBehaviour
{
    public GameObject krillPrefab;
    public float spawnInterval = 2f;
    private float timeSinceLastSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeSinceLastSpawn = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if(timeSinceLastSpawn >= spawnInterval){
            Instantiate(krillPrefab,transform.position,Quaternion.identity);
            timeSinceLastSpawn = 0f;
        }
    }
}
