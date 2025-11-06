using UnityEngine;

public class PuzzleMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public float moveSpeed = 3f;
    private Vector2 movementDirection;
    // Update is called once per frame
    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
    void FixedUpdate(){
        rb.linearVelocity = movementDirection * moveSpeed;
    }
}
