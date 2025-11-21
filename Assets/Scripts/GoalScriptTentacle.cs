using UnityEngine;
using UnityEngine.SceneManagement;
public class GoalScriptTentacle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void OnMouseDown(){
        Debug.Log("Success!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //next puzzle
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
