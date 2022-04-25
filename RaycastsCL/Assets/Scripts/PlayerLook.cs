using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float range = 100f;
    public float mouseSensitivity = 100f;

    public Transform playerBody;
    //public GameObject hitEffect;
    public Camera fpsCam;

    public int score = 0;

    float xRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;                                                           //locks the cursor to the centre
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;                        //sets the x-axis value
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;                        //sets the y-axis value

        xRotation -= mouseY;                                                                                //controls y-axis rotation of the camera
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);                                                      //ensures that the camera look up and down is clamped within certain limits

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);                                      //sets the camera local rotation based on mouse look along the x-axis
        playerBody.Rotate(Vector3.up * mouseX);                                                             //rotates the player object based on the rotation along the x-axis

        if(Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()                                                                                            //function to raycast and check for objects hit
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))            //checks if raycast hits an object
        {
            // GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));     //instantiates an object on hit
            // Destroy(impact, 2f);                                                                            //destroys the object instantiated after 2s

            TargetScript target = hit.transform.GetComponent<TargetScript>();                               //references the TargetScript on the object the ray hits

            if(target != null)                                                                              //checks if the target hit has the TargetScript
            {
                score++;                                                                                    //increases score
                target.Die();                                                                               //destroys object;
            }
        }
    }
}
