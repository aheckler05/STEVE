using UnityEngine;

public class KrillScript : MonoBehaviour
{
    public float movementSpeed = 2f;
    public Vector2 pointA;
    public Vector2 pointB;
    public float minRange = -5f;
    public float maxRange = 5f;

    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("eat");
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
        if(enemyHealth.boss){
            enemyHealth.Heal();
        }else{
            enemyHealth.TakeDamage(5);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float randomX = Random.Range(minRange, maxRange);
        float randomY = Random.Range(minRange, maxRange);
        Vector2 randomVector = new Vector2(randomX, randomY);
        pointA = transform.position;
        pointB = randomVector;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Mathf.PingPong(Time.time * movementSpeed, 1);
        transform.position = Vector2.Lerp(pointA, pointB, t);
    }
}
