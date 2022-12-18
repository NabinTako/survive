using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    private int Gamescore;
    private int surviveTime;

    public Text scoreText;
    public Text timeText;

    private bool isAlive = true;
    private void Start()
    {
        scoreText.text = "Score: ";
        timeText.text = "Time: ";
        StartCoroutine(survivalTime());
    }
    public void addScore(int score)
    {
        Gamescore = Gamescore + score;
        scoreText.text = "Score: " + Gamescore;
    }
    public void stopTime()
    {
        isAlive = false;
    }
    IEnumerator survivalTime()
    {
       while (isAlive)
        {
            yield return new WaitForSeconds(1f);
            surviveTime++;
            timeText.text = "Time: " + surviveTime + "sec";
       }
    }
}
