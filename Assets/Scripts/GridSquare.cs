using UnityEngine;

using UnityEngine.SceneManagement;
public class GridSquare : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float flashDelay;
    public bool flashes;
    public bool isWhite;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        if(flashes){
            Invoke("Flash", flashDelay);
            Invoke("Normal", flashDelay+1);
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }
    void Flash(){
        spriteRenderer.color = new Color(0f,0f,1f,1f);
    }
    void Normal(){
        if(isWhite){
            spriteRenderer.color = new Color(1f,1f,1f,1f);
        }else{
            spriteRenderer.color = new Color(0f,0f,0f,1f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(!flashes){
            audioManager.PlaySFX(audioManager.death);
            transform.localScale = new Vector3(1.5f, 1.5f, 1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
