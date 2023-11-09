using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI _scoreText;


    private void Start()
    {
        _scoreText.text = "";
    }
    void Update()
    {
    }
    public void DetermineScoreMessage(int numberOfShoots)
    {
        if (numberOfShoots <= 3)
        {
            _scoreText.text = "INCROYABLE !";
        }
        else if (numberOfShoots <= 5)
        {
            _scoreText.text = "WOW !";
        }
        else if (numberOfShoots <= 7)
        {
            _scoreText.text = "MOUAIS !";
        }
        else
        {
            _scoreText.text = "LOOSER !";
        }
    }

    internal void DetermineScoreMessage()
    {
        throw new NotImplementedException();
    }
}