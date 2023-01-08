using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    private int Gamescore;
    private int surviveTimesec;
    private int surviveTimemin;
    private int bestScore;

    public int level;
    private string[] getscore = {"BestScoreEasy", "BestScoreMedium" , "BestScoreHard" };

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
        bestScore = PlayerPrefs.GetInt(getscore[level], 0);
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
        PlayerPrefs.SetInt(getscore[level], Gamescore);
    }

    public int getSurviveTimemin()
    {
        return surviveTimemin;
    }
    public int getSurviveTimesec()
    {
        return surviveTimesec;
    }
    IEnumerator survivalTime()
    {
       while (isAlive)
        {
            yield return new WaitForSeconds(1f);
            surviveTimesec++;
            timeText.text = "Time: " + surviveTimemin + " : "+ surviveTimesec;

            if (surviveTimesec == 59)
            {
                surviveTimemin++;
                surviveTimesec = 0;
            }
       }
    }
}
