using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelButtons : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     public void level1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
