using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    void Start()
    {
        
    }

    public void Play() 
    {
        SceneManager.LoadScene("Level Select");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
