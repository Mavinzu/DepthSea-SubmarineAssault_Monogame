using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public GameObject spritePlayerRef;
    public TMP_Text scoreText, healthText, targetText, timerText;

    public static int score, health, target;
    public static float timer;
    public static int scoreIndex, healthIndex;
    public static int targetIndex = 10;
    public static float timerIndex;
    float timerColor = 1f;
    bool isChangeColor;
    void Start()
    {
        health = 3;
        scoreIndex = 1;
        healthIndex = 1;
        timerIndex = 5f;
        timer = timerIndex;
        target = targetIndex;
    }

    // Update is called once per frame
    void Update()
    {
        AddScore();
        DisHealth();
        TimerCheck();
        TargetText();
    }
    void AddScore()
    {
        scoreText.text = "Score : " + score;
    }
    void DisHealth()
    {
        healthText.text = "Health : " + health;
        if(health == 0)
        {
            SceneManager.LoadScene(2);
        }
    }
    void TimerCheck()
    {
        
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        timerText.text = Math.Round(timer, 2).ToString();
        if(timer <= 0)
        {
            timer = timerIndex;
            isChangeColor = true;
            health--;
        }
        if(isChangeColor)
        {
            timerColor -= Time.deltaTime;
            spritePlayerRef.GetComponent<SpriteRenderer>().color = new Color(1, (float)0.48, 0, 1);
        }
        if(timerColor <= 0)
        {
            timerColor = 1f;
            isChangeColor = false;
            spritePlayerRef.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
    }
    void TargetText()
    {
        targetText.text = "Target Score : " + target;
        if(score >= target)
        {
            SceneManager.LoadScene(2);
        }
    }
}
