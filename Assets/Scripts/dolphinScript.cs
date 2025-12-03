using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class dolphinController : MonoBehaviour
{
    private bool alive=true;
    [SerializeField] private PuzzleMovement ptemp;
    AudioManager audioManager;
    public GameObject bubbleringprefab;
    public SpriteRenderer spriteRenderer;
    public Sprite attackSprite; 
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Squid")
        {
            //animation here
            audioManager.PlaySFX(audioManager.death);
            //spriteRenderer.sprite = attackSprite;
            transform.localScale = new Vector3(1.5f, 1.5f, 1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }
        else if(collision.gameObject.name == "box")
        {
            //animation here
            audioManager.PlaySFX(audioManager.death);
            //spriteRenderer.sprite = attackSprite;
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        ptemp=GameObject.FindWithTag("Player").GetComponent<PuzzleMovement>();
        StartCoroutine(BubbleBlowing());
    }
    void OnDisable()
    {
        this.alive=false;
    }
    private IEnumerator BubbleBlowing()
    {
        while(this.alive)
        {
            yield return new WaitForSeconds(5);
            //play bubble warning anim?
            Vector2 temp=ptemp.transform.position;
            GameObject bubble = Instantiate(bubbleringprefab,this.transform.position,Quaternion.identity,this.transform);
            bubble.GetComponent<BubbleRing>().sizetarget=2f;
            bubble.GetComponent<BubbleRing>().timetarget=2.5f;
            bubble.GetComponent<BubbleRing>().postarget=this.transform.position;
            bubble.GetComponent<BubbleRing>().Trigger();    
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

