using UnityEngine;

public class powerupscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    public GameObject wall;
    public GameObject box;
    private SpriteRenderer PlayerspriteRenderer;
    private SpriteRenderer wallrender;
    private SpriteRenderer boxRender;
    void OnCollisionEnter2D(Collision2D collision){
        Physics2D.IgnoreCollision(collider1,collider2,true);
        Physics2D.IgnoreCollision(collider2,collider3,true);
        PlayerspriteRenderer.color = new Color(0.5f,0.5f,0.5f,1f);
        wallrender.color = new Color(0.5f,0.5f,0.5f,1f);
        boxRender.color = new Color(0.5f,0.5f,0.5f,1f);
    }
    private Collider2D collider1;
    private Collider2D collider2;
    private Collider2D collider3;
    void Start()
    {
        collider1 = player.GetComponent<Collider2D>();
        collider2 = wall.GetComponent<Collider2D>();
        collider3 = box.GetComponent<Collider2D>();
        PlayerspriteRenderer = player.GetComponent<SpriteRenderer>();
        wallrender = wall.GetComponent<SpriteRenderer>();
        boxRender = box.GetComponent<SpriteRenderer>();
        
    }
}
