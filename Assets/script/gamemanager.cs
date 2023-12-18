using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }
    
    public void Awake(){
        if(_instance != null){
            Destroy(gameObject);
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Retry(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //faire apparaitre la balle et le timer
    public void StartGame(){
        
    }

    public void EndGame(string newLevel){
        //set timeout
        SceneManager.LoadScene(newLevel);
    }

    [SerializeField] string[] level = {"NiveauUn", "NiveauDeux", "NiveauTrois", "Winner", "HighScore"};
    int countLevel = 0;

    public void GestionOfTerrain(){
        if(PlayerPrefs.GetString("typeJeu") == "Tournoi"){
            countLevel++;
            EndGame(level[countLevel]);
        }else{
            countLevel = 0;
            EndGame("TrainingMenu");
        }
        
    }

    public void DisplayScoreMessage()
    {

    }
}