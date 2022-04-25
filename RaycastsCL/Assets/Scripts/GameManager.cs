using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject target;
    public GameObject player;
    Vector3 randomPos;

    public Text playerScore;
    public Text timeOnScreen;

    bool isRunning;

    public float time = 30;

    // Start is called before the first frame update
    void Start()
    {
        isRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        Timer();                                                        //starts timer
        randomPos = new Vector3(Random.Range(-6f,6f),transform.position.y,Random.Range(-6f,6f));    //initialises a random spawn position

        StartCoroutine("ItemSpawner");                                  //coroutine to spawn targets after a certain time limit

        playerScore.text = player.GetComponent<PlayerLook>().score.ToString();               //gets reference to the player and updates player score
    }

    IEnumerator ItemSpawner()
    {
        if(!isRunning)
        {
            isRunning = true;                                           //sets isrunning to true so that coroutine isn't run until current one completes
            Instantiate(target,randomPos,transform.rotation);           //spawns the target object

            yield return new WaitForSeconds(Random.Range(2.5f, 4f));

            isRunning = false;                                          //sets it back to false so that next time coroutine can be run

            yield return null;
        }
    }

    //function to have a timer
    void Timer()
    {
        if(time > 0)
        {
            time -= Time.deltaTime;                                 //counts down time
        }
        else
        {
            time = 0;                                               //in case of timer going to negative it resets the timer to 0 for accuracy reasons
        }

        DisplayTime(time);
    }

    void DisplayTime(float displayTime)
    {
        if(displayTime < 0)                                         //checks for negative time and resets it to zero
        {
            displayTime = 0;
        }

        float minutes = Mathf.FloorToInt(displayTime / 60);        //divides by 60 for minutes
        float seconds = Mathf.FloorToInt(displayTime % 60);        //modulo by 60 for seconds

        timeOnScreen.text = string.Format("{0:00} : {1:00}", minutes, seconds);     //displays time on MM::SS format
    }
}
