using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    private int Gamescore;
    private int surviveTime;
    private int bestScore;

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text timeText;
    [SerializeField]
    private Text Best;

    [SerializeField]
    private bool isAlive = true;
    private void Start()
    {
        scoreText.text = "Score: ";
        timeText.text = "Time: ";
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        Best.text = "Best: " + bestScore;
        StartCoroutine(survivalTime());
    }
    public void addScore(int score)
    {
        Gamescore = Gamescore + score;
        scoreText.text = "Score: " + Gamescore;
        if (Gamescore > bestScore)
            Best.text = "Best: " + Gamescore;
    }
    public void stopTime()
    {
        isAlive = false;
        PlayerPrefs.SetInt("Best Score", Gamescore);
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
