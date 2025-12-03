using UnityEngine;

public class SandScript : MonoBehaviour
{
    public GameObject sandeye;
    public GameObject sand;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision){
        sandeye.SetActive(true);
        Invoke("cleanup", 3f);
    }
    void cleanup(){
        sandeye.SetActive(false);
        sand.SetActive(false);
    }
}
