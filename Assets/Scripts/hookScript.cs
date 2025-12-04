using UnityEngine;
using UnityEngine.SceneManagement;

public class hookScript : MonoBehaviour
{

    AudioManager audioManager;
    bossController boss;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        boss = GameObject.FindFirstObjectByType<bossController>();
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "Squid (1)"){
            //animation here
            audioManager.PlaySFX(audioManager.death);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }
    }
}
