using UnityEngine;
using System.Collections;

public class bombScript : MonoBehaviour
{

    AudioManager audioManager;
    bossController boss;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        boss = GameObject.FindFirstObjectByType<bossController>();
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name.Contains("sandBottomLevel")){
            audioManager.PlaySFX(audioManager.explode);
            Destroy(this.gameObject);
        }
        if(collision.gameObject.name.Contains("shark(Clone)")){
            audioManager.PlaySFX(audioManager.explode);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.name.Contains("bomb(Clone)")){
            audioManager.PlaySFX(audioManager.explode);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.name.Contains("Hook")){
            audioManager.PlaySFX(audioManager.explode);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            boss.hookDecrease(1);
        }
    }

}

//egg