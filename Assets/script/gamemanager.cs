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
    int countLevel = 0;

    public void Retry(){
        if(PlayerPrefs.GetString("typeJeu") == "Tournoi"){
            countLevel = 0;
            SceneManager.LoadScene("NiveauUn");
        }else{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    //faire apparaitre la balle et le timer
    public void StartGame(){
        countLevel = 0;
    }

    public void EndGame(string newLevel){
        //set timeout
        SceneManager.LoadScene(newLevel);
    }

    [SerializeField] string[] level = {"NiveauUn", "NiveauDeux", "NiveauTrois", "Winner", "HighScore"};
    

    public void GestionOfTerrain(){
        if(PlayerPrefs.GetString("typeJeu") == "Tournoi"){
            if(countLevel < level.Length - 1){
                countLevel++;
                EndGame(level[countLevel]);
            }else{
                countLevel = 1;
                EndGame(level[countLevel]);
            }
        }else{
            countLevel = 0;
            EndGame("TrainingMenu");
        }
        
    }
}