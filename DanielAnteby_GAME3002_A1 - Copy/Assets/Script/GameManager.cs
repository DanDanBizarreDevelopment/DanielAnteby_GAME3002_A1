using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Target score values
    public float redScore = 1;
    public float yellowScore = 5;
    public float greenScore = 10;

    //Total score value
    public Text scoreText;
    float score = 0;


    //Hit Green
    public void GreenTargetHit()
    {
        score += greenScore;
        scoreText.text = "Score: " + score;
    }
    //Hit Yellow
    public void YellowTargetHit()
    {
        score += yellowScore;
        scoreText.text = "Score: " + score;
    }
    //Hit Red
    public void RedTargetHit()
    {
        score += redScore;
        scoreText.text = "Score: " + score;
    }
}
