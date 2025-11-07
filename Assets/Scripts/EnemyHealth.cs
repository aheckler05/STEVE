using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public bool boss;
    public Image healthBarFill;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }
    public void UpdateHealthBar(){
        if(healthBarFill != null){
            healthBarFill.fillAmount = currentHealth/maxHealth;
        }
    }
    // Update is called once per frame
    public void TakeDamage(int damage){
        currentHealth -=damage;
        UpdateHealthBar();
        Debug.Log(currentHealth);
        if(currentHealth <=0){
            Destroy(gameObject);
            if(boss){
                SceneManager.LoadScene(4);
            }
        }
    }
    public void Heal(){
        currentHealth += 5;
        UpdateHealthBar();
    }
    void Update()
    {
        
    }
}
