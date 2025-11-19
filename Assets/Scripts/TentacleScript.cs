using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 offset;
    private bool isDragging = false;
    private Rigidbody2D rb;
    private bool alive = true;
    private SpriteRenderer spriteRenderer;
    
    void OnMouseDown(){
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }
    void OnMouseDrag(){
        if(isDragging && alive){
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //transform.position = new Vector3(mouseWorldPosition.x + offset.x, mouseWorldPosition.y+offset.y,transform.position.z);
            rb.MovePosition(mouseWorldPosition);
        }
    }
    void OnMouseUp(){
        isDragging = false;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "Urchin"){
            Debug.Log("Collision!");
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            alive = false;
            spriteRenderer.color = new Color(0.5f,0.5f,0.5f,1f);
        }
    }
}
