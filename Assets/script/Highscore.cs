using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Highscore : MonoBehaviour
{
    public TextMeshProUGUI highscoreText; // Le Text UI où tu veux afficher les scores

    void Start()
    {
        DisplayHighscores();
    }

    void DisplayHighscores()
    {
        string display = "Highscores:\n";
        string[,] listOfPlayers = new string[100, 100];

        int count = 1;
        while (PlayerPrefs.HasKey("Player_" + count))
        {
            string playerData = PlayerPrefs.GetString("Player_" + count);
            Player player = JsonUtility.FromJson<Player>(playerData);

            listOfPlayers[count - 1, 0] = player.playerName.ToString();
            listOfPlayers[count - 1, 1] = player.score.ToString();


            count++;
        }

        // Sort the list by score and display the top 10
        //Array.Sort(listOfPlayers);
        //Array.Reverse(listOfPlayers);

        for (int i = 0; i < 10; i++)
        {
            display += listOfPlayers[i,0] + " -> " + listOfPlayers[i,1] + "\n";
        }

        Debug.Log(display);

        // Affiche les highscores dans ton Text UI
        highscoreText.text = display;
    }
}

