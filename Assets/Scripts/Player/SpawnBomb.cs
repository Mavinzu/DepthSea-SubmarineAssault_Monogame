using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBomb : MonoBehaviour
{
    public GameObject refBomb;
    int bombAmount = 3;
    int bombIndex = 0;
    GameObject[] bombObject;

    float timerSpawn = 1f;
    float timerSpawnCount;
    bool isSpawn;
    void Start()
    {
        bombObject = new GameObject[bombAmount];
        for(int i = 0; i < bombAmount; i++)
        {
            bombObject[i] = Instantiate(refBomb);
            bombObject[i].SetActive(false);
        }
        timerSpawnCount = timerSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        PlaceBomb();
        TimerSpawn();
    }
    void PlaceBomb()
    {
        if(Input.GetKeyDown(KeyCode.Space) && bombIndex < bombObject.Length && !isSpawn)
        {
            bombObject[bombIndex].SetActive(true);
            bombObject[bombIndex].transform.position = new Vector2(transform.position.x - 2, transform.position.y);
            bombObject[bombIndex].GetComponent<CircleCollider2D>().enabled = false;
            bombIndex++;
            isSpawn = true;
        }
        if(bombIndex == bombObject.Length)
        {
            bombIndex = 0;
        }
    }
    void TimerSpawn()
    {
        if(isSpawn)
        {
            timerSpawnCount -= Time.deltaTime;
        }
        if(timerSpawnCount <= 0)
        {
            timerSpawnCount = timerSpawn;
            isSpawn = false;
        }
    }
}
