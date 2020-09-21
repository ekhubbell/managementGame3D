using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCircle : MonoBehaviour
{
    public GameObject[] prefabs;
    GameObject a;
   // GameObject a;
   // GameObject container;

    int cycleNumber;
    public int increaseSpawnsAt;
    int currentSpawns;
    public GameObject container;

    public bool[] hasSpawned;
    // Start is called before the first frame update
    void Start()
    {
        CountDownTimer.TimesUp += WhenToSpawn;
        CountDownTimer.TimesUp += CounterCycle;
    }

    private void Update()
    {
        if(currentSpawns < prefabs.Length)
        {
            currentSpawns = (int)(cycleNumber / increaseSpawnsAt);
        }
        
    }


    public void Spawn(int max)
    {
       a= Instantiate(prefabs[Random.Range(0,max)]);
       a.transform.SetParent(container.transform);
        a.GetComponent<RectTransform>().anchoredPosition = new Vector3(Random.Range(-430, 430), Random.Range(-250, 250), 0);
    }

    public void WhenToSpawn(float counter)
    {
        if(currentSpawns>0)
        {
            if (!hasSpawned[3] && counter <= 3 / currentSpawns)
            {
                Spawn(4);
                hasSpawned[3] = true;
            }
            else if (!hasSpawned[2] && counter <= 2 / currentSpawns)
            {
                Spawn(3);
                hasSpawned[2] = true;
            }
            else if (!hasSpawned[1] && counter <= 1 / currentSpawns)
            {
                Spawn(2);
                hasSpawned[1] = true;
            }
            else if (!hasSpawned[0] && counter <= 0 / currentSpawns)
            {
                Spawn(1);
                hasSpawned[0] = true;
                Reset(hasSpawned);
            }
        }
    }

    public void Reset(bool[] r)
    {
        for(int i=0; i<currentSpawns; i++)
        {
            hasSpawned[i] = false;
        }
    }

    public void CounterCycle(float countDown)
    {
        if(countDown<=0f)
        {
            cycleNumber++;
        }
    }
}
