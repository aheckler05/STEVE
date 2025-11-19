using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 offset;
    private bool isDragging = false;
    private Rigidbody2D rb;
    
    void OnMouseDown(){
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }
    void OnMouseDrag(){
        if(isDragging){
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
