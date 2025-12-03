using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class SnailShot : MonoBehaviour
{

    public Vector2 target;
    AudioManager audioManager;
    public SpriteRenderer spriteRenderer;
    public Sprite attackSprite; 
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Rigidbody2D>().position=Vector2.MoveTowards(this.gameObject.GetComponent<Rigidbody2D>().position,this.target,0.005f);
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "Squid")
        {
            //animation here
            audioManager.PlaySFX(audioManager.death);
            //spriteRenderer.sprite = attackSprite;
            transform.localScale = new Vector3(1.5f, 1.5f, 1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }
        else if (collision.gameObject.name == "box")
        {
            Vector2 targetpos=Vector2.LerpUnclamped(collision.otherRigidbody.position, collision.rigidbody.position,2f);
            collision.rigidbody.AddForce(targetpos*800);
            Destroy(this.gameObject);
        }
        else if(!(collision.gameObject.name == "Snail"))
        {
            Destroy(this.gameObject);
        }
    }
}
