using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 1f;
    SpriteRenderer sprite;
    float timer = 20f;
    float timerVanish = 0.5f;
    float timerCount;
    float timerVanishCount;
    void Start()
    {
        timerCount = timer;
        timerVanishCount = timerVanish;
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * transform.localScale.x * movementSpeed * Time.deltaTime);
        FishVanish();
    }

    void FishVanish()
    {
        if(timerCount > 0)
        {
            timerCount -= Time.deltaTime;
        }
        if(timerCount <= 0)
        {
            timerVanishCount -= Time.deltaTime;
        }
        if(timerVanishCount <= 0 && sprite.color.a >= 0)
        {
            timerVanishCount = timerVanish;
            sprite.color = new Color(1, 1, 1, sprite.color.a - 0.05f);
        }
        if(sprite.color.a <= 0)
        {
            gameObject.SetActive(false);
            sprite.color = new Color(1, 1, 1, 1);
            timerCount = timer;
            timerVanishCount = timerVanish;
        }
    }
}
