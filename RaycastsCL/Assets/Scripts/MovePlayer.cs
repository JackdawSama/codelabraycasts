using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;                                                   //library to access NavMesh and Ai functions

public class MovePlayer : MonoBehaviour
{
    public Camera cam;
    public float maxRange;
    public int score;
    Ray ray;
    RaycastHit hit;
    public NavMeshAgent player;                                         //reference to the player component's NavMesh Agent

    // Start is called before the first frame update
    void Start()
    {
        maxRange = 1;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    //function to move player character
    void PlayerMove()
    {
        if(Input.GetMouseButtonDown(1))                                 //checks for left mouse button input
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);            //stores the mouse position on screen as a ray

            if(Physics.Raycast(ray, out hit))                           //checks if the ray that is cast hits something
            {
                player.SetDestination(hit.point);                       //moves the player to the point that has been clicked
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Target")                            //checks for collison with tag Target
        {
            Destroy(other.gameObject);                                  //if true destroys target
            score++;                                                    //increases score
            Debug.Log(score);
        }    
    }
}
