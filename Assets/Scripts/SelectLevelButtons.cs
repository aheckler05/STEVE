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
    IEnumerator button1SFX()
    {
        audioManager.PlaySFX(audioManager.button);
        yield return new WaitForSecondsRealtime(audioManager.button.length);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
}
