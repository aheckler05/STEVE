using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class SnailController : MonoBehaviour
{
    private bool alive=true;
    [SerializeField] private PuzzleMovement ptemp;
    AudioManager audioManager;
    public GameObject snailshotprefab;


    private float speed=0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        ptemp=GameObject.FindWithTag("Player").GetComponent<PuzzleMovement>();
        StartCoroutine(ShotDelay(3));
    }

    // Update is called once per frame
    void Update()
    {
        //if(postarget!=this.transform.position)
       // {
       //     this.gameObject.GetComponent<Transform>().position=Vector2.MoveTowards(this.gameObject.GetComponent<Transform>().position,this.target,this.speed);
       // }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Squid")
        {
            //animation here
            if(collision.gameObject.GetComponent<PuzzleMovement>().CoconutCheck())
            {
                Destroy(this.gameObject);
                
            }
            else
            {
                //animation here
            audioManager.PlaySFX(audioManager.death);
            //spriteRenderer.sprite = attackSprite;
            transform.localScale = new Vector3(1.5f, 1.5f, 1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            
        }
        else if(collision.gameObject.name == "box")
        {
            //animation here
            audioManager.PlaySFX(audioManager.death);
            //spriteRenderer.sprite = attackSprite;
            Destroy(this.gameObject);

        }
    }
    void OnDisable()
    {
        this.alive=false;
    }
    private IEnumerator ShotDelay(float waittime)
    {
        while(this.alive)
        {
            yield return new WaitForSeconds(waittime);
            //play bubble warning anim?
            Vector2 temp=ptemp.transform.position;
            GameObject bullet = Instantiate(snailshotprefab,this.transform.position,Quaternion.identity,this.transform);
            bullet.GetComponent<SnailShot>().target=ptemp.transform.position;
            bullet.GetComponent<SnailShot>().target=Vector2.LerpUnclamped(this.transform.position,ptemp.transform.position,100f);
        }
    }


}
