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
    public void DisplayTime(float count)
    {
        textMesh.text = string.Format("Coups : " + count.ToString());
    }

    internal void DisplayTime()
    {
        throw new NotImplementedException();
    }
}