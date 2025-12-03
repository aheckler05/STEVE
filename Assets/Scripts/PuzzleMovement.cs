using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class PuzzleMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private bool ragdolled=false;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public int Lives=6;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    }
}
