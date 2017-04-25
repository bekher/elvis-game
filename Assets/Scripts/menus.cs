using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menus : MonoBehaviour {
    private bool paused;
    private bool started;
    public bool hasLost;
    int numGrannies;
    Text infoText;
    Text descText;

    // Use this for initialization
    void Start () {
        infoText = GameObject.Find("InfoText").GetComponent<Text>();
        descText = GameObject.Find("InfoSub").GetComponent<Text>();
        paused = false;
        numGrannies = 3;
        infoText.text = "";
        started = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (started)
        {
            if (!hasLost && Input.GetKeyDown(KeyCode.P))
            {
                paused = !paused;
            }
            else if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }

            if (paused && !hasLost)
            {
                infoText.text = "Paused";
                descText.text = "Press P to unpause";
                Time.timeScale = 0;
            }
            else
            {
                if (numGrannies > 0 && !hasLost)
                {
                    infoText.text = "";
                    descText.text = "";
                }
                Time.timeScale = 1;
            }
        }
	}

    public void GrannyDied()
    {
        numGrannies--;
        if (numGrannies <= 0 && !hasLost)
        {
            //paused = true;
            infoText.text = "You Won!";
            descText.text = "Press R to play again";
        }
    }

    public bool isStarted()
    {
        return started;
    }

    public void start()
    {
        started = true;
        Destroy(GameObject.Find("IntroPanel"));
        GetComponent<grannyGenerator>().gameStarted();
    }

    public void lost()
    {
        hasLost = true;
        infoText.text = "You lost!";
        descText.text = "Press R to try again";
        GameObject.Find("elvis").GetComponent<elvisAnim>().died();
    }
}
