using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float _timeRemaining = 20;
    private bool _timerIsRunning = false;
    private bool _isPaused = false; // Nouvelle variable pour contrôler l'état de la pause
    [SerializeField] private TextMeshProUGUI _timeText;

    private void Start()
    {
        // Starts the timer automatically
        _timerIsRunning = true;
    }

    void Update()
    {
        if (_timerIsRunning && !_isPaused) // Ajout de !_isPaused pour vérifier si le jeu n'est pas en pause
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
                DisplayTime(_timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                _timeRemaining = 0;
                _timerIsRunning = false;
                GameManager.Instance.Retry();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        _timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void PauseTimer()
    {
        _isPaused = !_isPaused; // Inversion de l'état de pause
    }
}
