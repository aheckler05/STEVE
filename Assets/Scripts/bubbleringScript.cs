using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class BubbleRing : MonoBehaviour
{
    Rigidbody2D.SlideMovement slide=new Rigidbody2D.SlideMovement();
        
    AudioManager audioManager;
    public float sizetarget;
    public float timetarget;
    public Vector2 postarget;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public SpriteRenderer spriteRenderer;
    public Sprite attackSprite; 
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "Squid")
        {
            //animation here
            audioManager.PlaySFX(audioManager.death);
            //spriteRenderer.sprite = attackSprite;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }
        else if (collision.gameObject.name == "box")
        {
            Vector2 targetpos=Vector2.LerpUnclamped(collision.otherRigidbody.position, collision.rigidbody.position,2f);
            collision.rigidbody.AddForce(targetpos*800);
            Destroy(this.gameObject);
        }

        }
    public void Trigger()
    {
        this.transform.localScale=new Vector3(0f,0f,0f);
        this.slide.gravity=new Vector2(0f,0f);
        this.slide.useSimulationMove=true;
        StartCoroutine(BubbleBlow());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator BubbleBlow()
    {
        Vector3 start=this.transform.localScale;
        Vector3 end=Vector3.one*this.sizetarget;
        float timetaken = 0f;

        while(timetaken<this.timetarget)
        {
            float temp=timetaken/timetarget;
            this.transform.localScale = Vector3.Lerp(start,end,temp);
            timetaken += Time.deltaTime;
            Debug.Log(timetaken);
            yield return new WaitForSeconds(0.001f);
        }
        transform.localScale = end;
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }
}
