using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


public class PuzzleMovement : MonoBehaviour
{
    public Sprite coconutSprite;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    [SerializeField] private bool ragdolled=false;
    AudioManager audioManager;

    [SerializeField] private List<GameObject> Hearts=new List<GameObject>();
    public int coconutstacks=0;
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
    void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.gameObject.name=="Coconut"||collision.gameObject.CompareTag("Coconut"))&&this.coconutstacks<2)
        {   
            this.coconutstacks=this.coconutstacks+1;
            if(spriteRenderer != null && coconutSprite != null){
                spriteRenderer.sprite = coconutSprite;
            }
            Destroy(collision.gameObject);
        }
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }



    public int Lives=6;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public float moveSpeed = 3f;
    public Vector2 movementDirection;
    // Update is called once per frame
    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
    public void Ragdoll(float time)
    {
        this.ragdolled=true;
        float delta=0f;
        while(delta<time)
        {
            delta+=Time.deltaTime;
        }
        this.ragdolled=false;
    }
    void FixedUpdate()
    {
        if (!this.ragdolled)
        {
            rb.linearVelocity = movementDirection * moveSpeed;
        }
        
        
    }
        public void LifeLoss(int l)
    {
        this.Lives=this.Lives-l;
        audioManager.PlaySFX(audioManager.damage);
        if(this.Lives<=0)
        {
            audioManager.PlaySFX(audioManager.death);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        Hearts[5-this.Lives].SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name == "Oil"){
            moveSpeed = 1f;
            Invoke("fix", 3f);
        }
    }
    public void fix(){
        moveSpeed = 3f;
    }
}
