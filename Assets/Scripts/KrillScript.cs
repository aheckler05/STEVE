using UnityEngine;

public class KrillScript : MonoBehaviour
{
    public Vector2 target;
    [SerializeField] private PuzzleMovement ptemp;
    SpriteRenderer sprite;
    Color colortemp=Color.white;
    private bool coloringdone=false;
    public int colorindex=-1;
    public Vector2 currentpos;
void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Squid")
        {
            collision.gameObject.GetComponent<PuzzleMovement>().LifeLoss(1);
            Destroy(this.gameObject);
        }
    }
    void OnEnable()
    {
        this.ptemp=GameObject.FindWithTag("Player").GetComponent<PuzzleMovement>();
        this.sprite=this.gameObject.GetComponent<SpriteRenderer>();

        this.target=ptemp.gameObject.GetComponent<Transform>().position;
        this.target.x=this.target.x+Random.Range(-2,3);
        this.target=Vector2.LerpUnclamped(this.gameObject.GetComponent<Transform>().position,target,10f);

    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Transform>().position=Vector2.MoveTowards(this.gameObject.GetComponent<Transform>().position,this.target,0.015f);
        this.currentpos=this.gameObject.GetComponent<Transform>().position;
        if(currentpos.x>10||currentpos.x<-10||currentpos.y>5.5||currentpos.y<-5.5)
        {
            Destroy(this.gameObject);
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
