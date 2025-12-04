using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class anglerfishScript : MonoBehaviour
{

    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public SpriteRenderer spriteRenderer;
    public Sprite attackSprite; 
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "box" || collision.gameObject.name == "Squid"){
        if(collision.gameObject.name == "box")
        {
            //animation here
            audioManager.PlaySFX(audioManager.death);
            spriteRenderer.sprite = attackSprite;
            transform.localScale = new Vector3(1.5f, 1.5f, 1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }
        else if (collision.gameObject.name == "Squid")
        {
            if(collision.gameObject.GetComponent<PuzzleMovement>().CoconutCheck())
            {
                //animation here
                audioManager.PlaySFX(audioManager.death);
                //spriteRenderer.sprite = attackSprite;
                Destroy(this.gameObject);
            }
            else
            {
                audioManager.PlaySFX(audioManager.death);
                spriteRenderer.sprite = attackSprite;
                transform.localScale = new Vector3(1.5f, 1.5f, 1f);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
