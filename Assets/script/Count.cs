using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Count : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;

    private void Start()
    {
    }
    void Update()
    {
    }
    public void DisplayCount(float count)
    {
        textMesh.text = string.Format("Coups : " + count.ToString());
    }

    internal void DisplayCount()
    {
        throw new NotImplementedException();
    }

    public void DetermineScoreMessage(int numberOfShoots)
    {
        if (numberOfShoots <= 3)
        {
            textMesh.text = "Excellent !";
        }
        else if (numberOfShoots <= 5)
        {
            textMesh.text = "Très bien !";
        }
        else if (numberOfShoots <= 7)
        {
            textMesh.text = "Pas mal !";
        }
        else
        {
            textMesh.text = "Peux mieux faire !";
        }
    }
}