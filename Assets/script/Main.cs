using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public string gameSceneName = "NiveauUn"; // Le nom de la scène du jeu

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void Retry()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
