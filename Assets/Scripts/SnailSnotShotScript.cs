using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class SnailShot : MonoBehaviour
{

    public Vector2 target;
    public bool targetted=false;
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
        /*if(!targetted)
        {
            float angle = Mathf.Atan2(this.target.y - this.transform.position.y, this.target.x -this.transform.position.x ) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.rotation = Quaternion.RotateTowards(this.transform.rotation, targetRotation, 1 * Time.deltaTime);
            this.targetted=true;
        }*/
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
            Vector2 direction = collision.contacts[0].point - (Vector2)this.transform.position;
		    direction = -direction.normalized;
		    GetComponent<Rigidbody>().AddForce(direction*100);
            Destroy(this.gameObject);
        }
        else if(!(collision.gameObject.name == "Snail"))
        {
            Destroy(this.gameObject);
        }
    }

}
