using UnityEngine;
using UnityEngine.SceneManagement;
public class boxScript : MonoBehaviour
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "Goal"){
            audioManager.PlaySFX(audioManager.win);
            //scene transition here
            if(SceneManager.GetActiveScene().buildIndex+1 < SceneManager.sceneCountInBuildSettings){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            }else{
                SceneManager.LoadScene(0);
            }
            //update currency
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
