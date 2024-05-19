using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject fishRef;
    public GameObject[] fishGroup1;
    public GameObject[] fishGroup2;
    int fishAmount = 15;
    int fishIndex1 = 0;
    int fishIndex2 = 0;
    public Vector2 dir;

    float timerSpawn = 1f;
    public float timerSpawnCount;
    void Start()
    {
        fishGroup1 = new GameObject[fishAmount];
        fishGroup2 = new GameObject[fishAmount];
        for(int i = 0; i < fishAmount; i++)
        {
            fishGroup1[i] = Instantiate(fishRef);
            fishGroup1[i].SetActive(false);
            fishGroup2[i] = Instantiate(fishRef);
            fishGroup2[i].transform.localScale = new Vector3(-1, 1, 1);
            fishGroup2[i].SetActive(false);
        }
        timerSpawnCount = timerSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTimer();
    }
    
    void SpawnTimer()
    {
        if(fishIndex1 != fishGroup1.Length || fishIndex2 != fishGroup2.Length)
        {
            timerSpawnCount -= Time.deltaTime;
        }
        if(timerSpawnCount <= 0 && fishIndex1 < fishAmount)
        {
            Vector3 camPos = Camera.main.transform.position;
            dir = new Vector2(Random.Range(camPos.x - 60, camPos.x + 61), Random.Range(camPos.y - 40, camPos.y + 41));
            if(dir.x <= camPos.x - 59)
            {
                timerSpawnCount = timerSpawn;
                fishGroup1[fishIndex1].transform.position = new Vector2(dir.x, dir.y);
                fishGroup1[fishIndex1].SetActive(true);
                fishIndex1++;
            }
            if(dir.x >= camPos.x + 59)
            {
                timerSpawnCount = timerSpawn;
                fishGroup2[fishIndex2].transform.position = new Vector2(dir.x, dir.y);
                fishGroup2[fishIndex2].SetActive(true);
                fishIndex2++;
            }
        }
        if(fishIndex1 == fishAmount)
        {
            fishIndex1 = 0;
        }
        if(fishIndex2 == fishAmount)
        {
            fishIndex2 = 0;
        }
    }
}
