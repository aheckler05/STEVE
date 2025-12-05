using UnityEngine;
using System.Collections;

public class bombScript : MonoBehaviour
{
    public GameObject explode;
    public GameObject blood;
    public GameObject death;
    AudioManager audioManager;
    bossController boss;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        boss = GameObject.FindFirstObjectByType<bossController>();
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name.Contains("sandBottomLevel")){
            Instantiate(explode, transform.position, Quaternion.identity);
            audioManager.PlaySFX(audioManager.explode);
            Destroy(this.gameObject);
        }
        if(collision.gameObject.name.Contains("shark(Clone)")){
            Instantiate(explode, transform.position, Quaternion.identity);
            Instantiate(blood, collision.gameObject.transform.position, Quaternion.identity);
            audioManager.PlaySFX(audioManager.explode);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.name.Contains("bomb(Clone)")){
            Instantiate(explode, transform.position, Quaternion.identity);
            audioManager.PlaySFX(audioManager.explode);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.name.Contains("Hook")){
            Instantiate(explode, transform.position, Quaternion.identity);
            audioManager.PlaySFX(audioManager.explode);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            boss.hookDecrease(1);
        }
    }

}

//egg