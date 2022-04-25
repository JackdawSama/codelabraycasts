using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public float amplitude;
    // Start is called before the first frame update
    void Start()
    {
        amplitude = 1f;                                                             //sets a default amplitude value
    }

    // Update is called once per frame
    void Update()
    {
            TrigMov();                                                              //class the TrigMov function to oscillate the target
    }

    void TrigMov()                                                                  //function to make the target socillate along the y-axis
    {
        float x = Mathf.Sin(Time.time) * amplitude;                                 //makes the object oscilate along the X based on the amplitude
        float y = transform.position.y;                                             //updates the position along y
        float z = transform.position.z;                                             //updates the position along y

        transform.position = new Vector3(x, y, z);                                  //updates the position of the object
    }

    public void Die()                                                               //public function to destroy the object
    {
        Destroy(gameObject);
    }
}
