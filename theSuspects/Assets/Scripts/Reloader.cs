using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reloader : MonoBehaviour
{
    public NewCharSetup setup;
    public GameObject winCanvas;
    public Text scoreText;
     public void LoadNewScene()
    {
        winCanvas.SetActive(true);
        float score = 10000 - setup.clickCount * 115;
        scoreText.text = "Your score: " + score.ToString();
    }
}