using UnityEngine;
using UnityEngine.SceneManagement;
public class anglerfishScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "box" || collision.gameObject.name == "Squid"){
            //animation here
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
