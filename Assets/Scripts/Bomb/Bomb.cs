using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    float timerAnim = 1f;
    float timerAnimCount;
    float timerDone = 0.3f;
    void Start()
    {
        timerAnimCount = timerAnim;
    }

    // Update is called once per frame
    void Update()
    {
        timerAnimCount -= Time.deltaTime;
        if(timerAnimCount <= 0)
        {
            GetComponent<Animator>().SetBool("IsDuar", true);
            GetComponent<CircleCollider2D>().enabled = true;
            timerDone -= Time.deltaTime;
            if(timerDone <= 0)
            {
                gameObject.SetActive(false);
                timerAnimCount = timerAnim;
                timerDone = 0.3f;
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Shark"))
        {
            other.gameObject.SetActive(false);
            UiManager.score += UiManager.scoreIndex;
            UiManager.timer = UiManager.timerIndex;
        }
        if(other.gameObject.CompareTag("Player"))
        {
            UiManager.health -= UiManager.healthIndex;
        }
    }
}
