using UnityEngine;

public class whaleScript : MonoBehaviour
{
    public GameObject krillPrefab;
    public float spawnInterval = 2f;
    private float timeSinceLastSpawn;
    public float movementSpeed = 2f;
    public Vector2 pointA;
    public Vector2 pointB;
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

        float t = Mathf.PingPong(Time.time * movementSpeed, 1);

        transform.position = Vector2.Lerp(pointA, pointB, t);
    }
}
