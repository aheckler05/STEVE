using UnityEngine;

public class attackScript : MonoBehaviour
{
    public int attackDamage = 10;
    void OnTriggerEnter2D(Collider2D other){
        //if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("hit");
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if(enemyHealth != null){
                enemyHealth.TakeDamage(attackDamage);
            }
        //}
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
