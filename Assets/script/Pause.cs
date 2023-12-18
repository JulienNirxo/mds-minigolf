using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenuUI;
    //button resume
    public Button resumeButton;
    //button restart
    public Button quit;
    private bool isPaused = false;

    void Start()
    {
        DontDestroyOnLoad(pauseMenuUI);
        pauseMenuUI.SetActive(false); // Désactive le menu de pause au début du jeu
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Arrête le temps dans le jeu pour le mettre en pause
        pauseMenuUI.SetActive(true); // Active le menu de pause
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Reprend le temps normal dans le jeu
        pauseMenuUI.SetActive(false); // Désactive le menu de pause
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
