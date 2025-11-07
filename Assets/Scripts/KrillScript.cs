using UnityEngine;

public class KrillScript : MonoBehaviour
{
    public float movementSpeed = 2f;
    public Vector2 pointA;
    public Vector2 pointB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pointA = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Mathf.PingPong(Time.time * movementSpeed, 1);
        transform.position = Vector2.Lerp(pointA, pointB, t);
    }
}
