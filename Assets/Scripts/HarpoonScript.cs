using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class HarpoonScript : MonoBehaviour
{

    [SerializeField] private whaleScript whaleref;
    [SerializeField] private PuzzleMovement ptemp;
    public int colorindex=-1;
    private bool coloringdone=false;
    private Vector2 target;
    private Vector2 startpos;
    private bool enroute=false;
    Color colortemp=Color.white;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void OnEnable()
    {
        this.whaleref=GameObject.Find("Whale").GetComponent<whaleScript>();
        this.target=whaleref.gameObject.GetComponent<Transform>().position;
        this.ptemp=GameObject.FindWithTag("Player").GetComponent<PuzzleMovement>();

        this.gameObject.transform.localScale=new Vector3(5f,5f,0f);
        startpos.y=Random.Range(-4.5f,4.5f);
        int tempbool=Random.Range(0,2);
        if(startpos.y>0){if(tempbool>0){startpos.x=Random.Range(3f,8.5f);}else{startpos.x=Random.Range(-8.5f,-3f);}}
        else{startpos.x=Random.Range(-8.5f,8.5f);}

        this.gameObject.GetComponent<Transform>().position=startpos;

        

    }

    // Update is called once per frame
    void Update()
    {
        if(enroute)
        {
            this.gameObject.GetComponent<Transform>().position=Vector2.MoveTowards(this.gameObject.GetComponent<Transform>().position,this.target,0.06f);
        }
        if(this.gameObject.GetComponent<Transform>().position==(Vector3)this.target)
        {
            whaleref.Damage(2);
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        int tempcheck=0;
        if(collision.gameObject.name == "Squid"&&!this.enroute&&whaleref.ColorPattern.TryPeek(out tempcheck))
        {
            if(this.colorindex==tempcheck)
            {
                this.enroute=true;
                whaleref.ColorPattern.Dequeue();
                if(whaleref.ColorPattern.Count<1)
                {
                    whaleref.patterncomplete=true;
                }
            }
            else
            {
                collision.gameObject.GetComponent<PuzzleMovement>().LifeLoss(1);
                whaleref.Damage(0);
                if(whaleref.ColorPattern.Contains(this.colorindex))
                {
                Vector2 direction = collision.contacts[0].point - (Vector2)this.transform.position;
		        direction = -direction.normalized;
		        GetComponent<Rigidbody2D>().AddForce(direction*0.5f);
                }
                else
                {
                    Destroy(this.gameObject);
                }

            }
        }
    }
    public bool Coloring(int index)
    {
        this.colorindex=index;
        switch (index)
        {
            case 0:
                this.gameObject.GetComponent<SpriteRenderer>().color=Color.red;
            break;
            case 1:
                this.gameObject.GetComponent<SpriteRenderer>().color=Color.green;
            break;
            case 2:
                this.gameObject.GetComponent<SpriteRenderer>().color=Color.blue;
            break;
            case 3:
                this.gameObject.GetComponent<SpriteRenderer>().color=Color.cyan;
            break;
            case 4:
                this.gameObject.GetComponent<SpriteRenderer>().color=Color.magenta;
            break;
            case 5:
                this.gameObject.GetComponent<SpriteRenderer>().color=Color.yellow;
            break;
            case 6:
                this.gameObject.GetComponent<SpriteRenderer>().color=Color.black;
            break;
            case 7:
                this.gameObject.GetComponent<SpriteRenderer>().color=Color.pink;
            break;
            default:
                this.gameObject.GetComponent<SpriteRenderer>().color=Color.white;
            break;
        }
        this.coloringdone=true;
        return true;
    }
}
