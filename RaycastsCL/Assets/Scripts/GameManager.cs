using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject target;
    Vector3 randomPos;

    Text playerScore;

    bool isRunning;

    MovePlayer scoreCounter;

    // Start is called before the first frame update
    void Start()
    {
        isRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        randomPos = new Vector3(Random.Range(-6f,6f),transform.position.y,Random.Range(-6f,6f));

        StartCoroutine("ItemSpawner");
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
}
