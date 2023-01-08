using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spanBosses : MonoBehaviour
{
    score score;
    [SerializeField]
    private GameObject Boss;
    [SerializeField]
    private GameObject Audio;
    [SerializeField]
    private GameObject BossAudio;

    int[] times = { 0, 1, 2 };
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Canvas").GetComponent<score>();
    }

    // Update is called once per frame
    void Update()
    {
        if (score.getSurviveTimemin() == times[index]/* 4 min */ && score.getSurviveTimesec()>50)
        {
            Boss.SetActive(true);
            Audio.SetActive(false);
            BossAudio.SetActive(true);
            if (score.getSurviveTimemin() > times[index + 1] /* 5 min */)
            {
                spanBoss();
                index = 1;
            }
        }
        if(score.getSurviveTimemin() > 4 /* 4 min */ && score.getSurviveTimesec() > 30)
        {
            Audio.SetActive(true);
            BossAudio.SetActive(false);
        }
    }

    void spanBoss()
    {
        Debug.Log("Boss Spaned"); 
    }
}
