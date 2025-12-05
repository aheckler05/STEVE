using UnityEngine;
using UnityEngine.SceneManagement;
public class SimonSaysMovement : MonoBehaviour
{
    public Sprite coconutSprite;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    public float moveDistance = 1f;
    private float x = 0;
    private float y = 0;
    public bool slugged = false;
    AudioManager audioManager;
    public int coconutstacks=0;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "Goal"){
            audioManager.PlaySFX(audioManager.win);
            //scene transition here
            if(SceneManager.GetActiveScene().buildIndex+1 < SceneManager.sceneCountInBuildSettings){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            }else{
                SceneManager.LoadScene(0);
            }
            //update currency
        }
        else if((collision.gameObject.name=="Coconut"||collision.gameObject.CompareTag("Coconut"))&&this.coconutstacks<2)
        {   
            this.coconutstacks=this.coconutstacks+1;
            if(spriteRenderer != null && coconutSprite != null){
                spriteRenderer.sprite = coconutSprite;
            }
            Destroy(collision.gameObject);
        }
    }
    //public float moveSpeed = 3f;
    //private Vector2 movementDirection;
    // Update is called once per frame

    public bool CoconutCheck()
    {
        if(this.coconutstacks>0)
        {
            this.coconutstacks=this.coconutstacks-1;
            return true;
        }
        else
        {
            return false;
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)){
            if(!slugged){
                y = moveDistance;
                x = 0;
            }else{
                y = -moveDistance;
                x = 0;
            }
        }else if(Input.GetKeyDown(KeyCode.S)){
            if(!slugged){
            y = -moveDistance;
            x = 0;
            }else{
                y = moveDistance;
                x = 0;
            }
        }else if(Input.GetKeyDown(KeyCode.A)){
            if(!slugged){
                x = -moveDistance;
                y = 0;
            }else{
                x = moveDistance;
                y = 0;
            }
        }else if(Input.GetKeyDown(KeyCode.D)){
            if(!slugged){
                x = moveDistance;
                y = 0;
            }else{
                x = -moveDistance;
                y=0;
            }
        }
        transform.position = new Vector2(transform.position.x+x,transform.position.y+y);
        y=0;x=0;
        
    }
    void onTriggerEnter2D(Collider2D collision){
        Debug.Log("collide");
        if(collision.gameObject.tag == "hazard"){
            slugged = true;
        }
    }
    
}
