using UnityEngine;
using UnityEngine.SceneManagement;
public class SimonSaysMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveDistance = 1f;
    private float x = 0;
    private float y = 0;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    }
    //public float moveSpeed = 3f;
    //private Vector2 movementDirection;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)){
            y = moveDistance;
            x = 0;
        }else if(Input.GetKeyDown(KeyCode.S)){
            y = -moveDistance;
            x = 0;
        }else if(Input.GetKeyDown(KeyCode.A)){
            x = -moveDistance;
            y = 0;
        }else if(Input.GetKeyDown(KeyCode.D)){
            x = moveDistance;
            y = 0;
        }
        transform.position = new Vector2(transform.position.x+x,transform.position.y+y);
        y=0;x=0;
        
    }
    
}
