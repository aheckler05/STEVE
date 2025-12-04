using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SelectLevelButtons : MonoBehaviour
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
     public void level1()
    {
        StartCoroutine(button1SFX());
    }
    public void level2(){
        StartCoroutine(button2SFX());
    }
    public void level3(){
        StartCoroutine(button3SFX());
    }
    IEnumerator button1SFX()
    {
        audioManager.PlaySFX(audioManager.button);
        yield return new WaitForSecondsRealtime(audioManager.button.length);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }// Update is called once per frame
    void Update(){
    
    }
    IEnumerator button2SFX()
    {
        audioManager.PlaySFX(audioManager.button);
        yield return new WaitForSecondsRealtime(audioManager.button.length);

        SceneManager.LoadScene(6);
        
    }
    IEnumerator button3SFX()
    {
        audioManager.PlaySFX(audioManager.button);
        yield return new WaitForSecondsRealtime(audioManager.button.length);

        SceneManager.LoadScene(9);
        
    }
}
