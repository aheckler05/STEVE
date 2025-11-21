using UnityEngine.SceneManagement;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static bool gamePaused = false;

    public GameObject pauseMenuUI;
    public GameObject pauseButton;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        } 
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void loadMenu()
    {
        Debug.Log("Loading menu");
        SceneManager.LoadScene("MainMenu");
        Resume();
    }

    public void quitGame()
    {
        Debug.Log("quitting");
        Application.Quit();
    }

    public void restartLevel()
    {
        Debug.Log("restarting level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();
    }
}
