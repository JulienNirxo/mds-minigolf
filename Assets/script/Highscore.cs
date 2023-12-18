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

    //tableau des highscores
    void DisplayHighscores()
    {
        //PlayerPrefs.DeleteAll();
        string display = "";
        string[,] listOfPlayers = new string[100, 100];
        //string 

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
        for (int i = 0; i < count - 1; i++)
        {
            for (int j = i + 1; j < count - 1; j++)
            {
                if (Convert.ToInt32(listOfPlayers[i, 1]) > Convert.ToInt32(listOfPlayers[j, 1]))
                {
                    string temp = listOfPlayers[i, 1];
                    listOfPlayers[i, 1] = listOfPlayers[j, 1];
                    listOfPlayers[j, 1] = temp;

                    temp = listOfPlayers[i, 0];
                    listOfPlayers[i, 0] = listOfPlayers[j, 0];
                    listOfPlayers[j, 0] = temp;
                }
            }
        }


        for (int i = 0; i < 5; i++)
        {
            display += listOfPlayers[i,0] + " : " + listOfPlayers[i,1] + "\n";
        }

        highscoreText.text = display;
    }
}

