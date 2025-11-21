using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class pauseMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static bool gamePaused = false;

    public GameObject pauseMenuUI;
    public GameObject pauseButton;

    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                Resume();
                audioManager.PlaySFX(audioManager.button);
            }
            else
            {
                Pause();
                audioManager.PlaySFX(audioManager.button);
            }
        } 
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
        gamePaused = false;
        audioManager.PlaySFX(audioManager.button);
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
        gamePaused = true;
        audioManager.PlaySFX(audioManager.button);
    }

    public void loadMenu()
    {
        StartCoroutine(menuLevelSFX());
    }

    public void quitGame()
    {
        Debug.Log("quitting");
        Application.Quit();
        audioManager.PlaySFX(audioManager.button);
    }


    public void restartLevel()
    {
        StartCoroutine(restartLevelSFX());
    }

    IEnumerator restartLevelSFX()
    {
        audioManager.PlaySFX(audioManager.button);
        yield return new WaitForSecondsRealtime(audioManager.button.length);

        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

        IEnumerator menuLevelSFX()
    {
        audioManager.PlaySFX(audioManager.button);
        yield return new WaitForSecondsRealtime(audioManager.button.length);

        Resume();
        SceneManager.LoadScene("MainMenu");
    }
}

