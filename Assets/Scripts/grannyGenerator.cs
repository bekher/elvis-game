using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grannyGenerator : MonoBehaviour {

    float startTime;
    bool firstSpawned;
    bool secondSpawned;
    public GameObject grannyPf;
    bool started;

	// Use this for initialization
	void Start () {
        startTime = 0;
        firstSpawned = secondSpawned = started = false;	
	}
	
	// Update is called once per frame
	void Update () {
        if (started)
        {
            if (!firstSpawned && startTime + 3 <= Time.time)
            {
                Instantiate(grannyPf, new Vector3(-7.5F, 0F, -5.4F), Quaternion.identity);
                firstSpawned = true;
            }
            if (!secondSpawned && startTime + 5 <= Time.time)
            {
                Instantiate(grannyPf, new Vector3(3.5F, 1.15F, 0F), Quaternion.identity);
                Instantiate(grannyPf, new Vector3(-1.25F, 0F, -2.25F), Quaternion.identity);
                secondSpawned = true;
            }
        }
	}

    public void gameStarted()
    {
        startTime = Time.time;
        started = true;
    }
}
