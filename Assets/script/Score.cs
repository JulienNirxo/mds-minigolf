using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Score : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI _scoreText;
    //textmesg inputfield
    [SerializeField] private TMP_InputField _nameInput;
    public int _score;
    Player currentPlayer;


    private void Start()
    {
        _scoreText.text = "";
    }
    void Update()
    {
    }

    //petit message
    public void DetermineScoreMessage(int numberOfShoots)
    {
        //set score
        _score = numberOfShoots;
        if (numberOfShoots <= 5)
        {
            _scoreText.text = "WOW !";
        }
        else if (numberOfShoots <= 7)
        {
            _scoreText.text = "Mouais...";
        }
        else if (numberOfShoots <= 9)
        {
            _scoreText.text = "LOOSER !";
        }
        else
        {
            _scoreText.text = "Pitoyable !";
        }

        PlayerPrefs.SetInt("score", _score + PlayerPrefs.GetInt("score"));
        PlayerPrefs.Save();
    }


    internal void DetermineScoreMessage()
    {
        throw new NotImplementedException();
    }

    //save score et nom du joueur
    public void SaveScore()
    {
        string playerName = _nameInput.text;

        int score = PlayerPrefs.GetInt("score");
        int count = 1;
        while (PlayerPrefs.HasKey("Player_" + count))
        {
            count++;
        }

        PlayerPrefs.SetString("Player_" + count, JsonUtility.ToJson(new Player { index = count, playerName = playerName, score = score }));
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.Save();

        SceneManager.LoadScene("HighScore");
    }
}