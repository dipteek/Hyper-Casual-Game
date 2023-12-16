
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 100;

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(new Vector3(0,speed * Time.deltaTime,0));
        transform.Rotate(Vector3.up,speed*Time.deltaTime);
    }
}
