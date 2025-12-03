using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class CrabScript : MonoBehaviour
{
    
    private Vector2 postarget;
    [SerializeField] List<Vector2> patrolpoints;
    [SerializeField] bool islooping=true;
    private float speed=0.1f;
    AudioManager audioManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        StartCoroutine(Patrol(this.patrolpoints,this.islooping));
    }

    // Update is called once per frame
    void Update()
    {
        if(postarget!=(Vector2)this.transform.position)
        {
            this.gameObject.GetComponent<Transform>().position=Vector2.MoveTowards(this.gameObject.GetComponent<Transform>().position,this.postarget,this.speed);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Squid"||collision.gameObject.name == "box")
        {
            //animation here
            audioManager.PlaySFX(audioManager.death);
            //spriteRenderer.sprite = attackSprite;
            transform.localScale = new Vector3(1.5f, 1.5f, 1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }
    }

    public IEnumerator Patrol(List<Vector2> patrolpoints, bool loop)
    {
        do
        {
        foreach(Vector2 p in patrolpoints)
        {
            this.postarget=p;
            yield return new WaitForSeconds(0.1f);
            yield return new WaitUntil(()=>this.postarget==(Vector2)this.transform.position);
        }
        }
        while(loop);
    }
}
