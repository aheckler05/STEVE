using UnityEngine;

public class boxScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("GOALLLLLL");
        if(collision.gameObject.name == "Goal"){
            Debug.Log("puzzle solved");
            //scene transition here
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
