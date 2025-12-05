using UnityEngine;

public class Clownfish : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform target;
    public float speed;
    public GameObject sbeve;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null){
            float distance = Vector2.Distance(transform.position, target.position);
            Vector2 direction = (target.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position,target.position, speed * Time.deltaTime);
            transform.LookAt(target);
        }
    }
    void OnMouseDown()
    {
        speed = 0f;
        sbeve.SetActive(false);
    }
}
