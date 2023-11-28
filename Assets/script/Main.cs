using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public void Niveau(string niveau)
    {
        PlayerPrefs.SetString("typeJeu", "Training");
        PlayerPrefs.Save();
        SceneManager.LoadScene(niveau);
    }

    public void StartTournois()
    {
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetString("typeJeu", "Tournoi");
        PlayerPrefs.Save();
        SceneManager.LoadScene("niveauUn");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
