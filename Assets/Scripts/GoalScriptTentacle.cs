using UnityEngine;
using UnityEngine.SceneManagement;
public class GoalScriptTentacle : MonoBehaviour
{
    public bool lastPuzzle;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnMouseDown(){
        Debug.Log("Success!");
        Collider2D myCollider = GetComponent<Collider2D>();
        Collider2D[] colliderAtPoint = Physics2D.OverlapPointAll(transform.position);
        Debug.Log("Overlapping = " + colliderAtPoint.Length);
        if (colliderAtPoint.Length == 1){
            audioManager.PlaySFX(audioManager.win);
            if(lastPuzzle){
                SceneManager.LoadScene(13);
            }else{
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }else{
            //Debug.Log("Blocked by " + colliderAtPoint.name);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
