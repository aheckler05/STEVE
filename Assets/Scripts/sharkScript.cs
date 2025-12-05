using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class sharkScript : MonoBehaviour
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public float detectRange = 5f;     // How close the player must be
    public float chargeForce = 10f;    // How strong the launch is
    public float cooldown = 2f;        // Time between charges

    private Transform player;
    private Rigidbody2D rb;
    private bool canCharge = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player == null) return;

        float dist = Vector2.Distance(transform.position, player.position);

        if (dist <= detectRange && canCharge)
        {
            StartCoroutine(Charge());
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "Squid (1)"){
            //animation here
            audioManager.PlaySFX(audioManager.death);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }
        if(collision.gameObject.name.Contains("Hook")){
            audioManager.PlaySFX(audioManager.hit);
            Destroy(this.gameObject);
        }
    }

    private IEnumerator Charge()
    {
        canCharge = false;

        // Calculate direction
        Vector2 dir = (player.position - transform.position).normalized;

        // Launch enemy
        rb.AddForce(dir * chargeForce, ForceMode2D.Impulse);

        // Wait for cooldown
        yield return new WaitForSeconds(cooldown);
        canCharge = true;
    }

}
