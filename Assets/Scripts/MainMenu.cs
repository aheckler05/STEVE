using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class MainMenu : MonoBehaviour
{

    AudioManager audioManager;
    
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void play()
    {
        StartCoroutine(playButtonSFX());
    }
    
    public void settingBtn()
    {
        audioManager.PlaySFX(audioManager.button);
    }
    public void quitGame()
    {
        Debug.Log("quitting");
        audioManager.PlaySFX(audioManager.button);
        Application.Quit();
    }

    IEnumerator playButtonSFX()
    {
        audioManager.PlaySFX(audioManager.button);
        yield return new WaitForSecondsRealtime(audioManager.button.length);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
}
