using UnityEngine;
using UnityEngine.SceneManagement;
public class anglerfishScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public SpriteRenderer spriteRenderer;
    public Sprite attackSprite; 
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "box" || collision.gameObject.name == "Squid"){
            //animation here
            spriteRenderer.sprite = attackSprite;
            transform.localScale = new Vector3(1.5f, 1.5f, 1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
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
