using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public float amplitude;
    // Start is called before the first frame update
    void Start()
    {
        amplitude = 1f;
    }

    // Update is called once per frame
    void Update()
    {
            TrigMov();                                                              //class the TrigMov function to oscillate the target
    }

    void TrigMov()                                                              //function to make the target socillate along the y-axis
    {
        float x = Mathf.Sin(Time.time) * amplitude;
        float y = transform.position.y;
        float z = transform.position.z;

        transform.position = new Vector3(x, y, z);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
