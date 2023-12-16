using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarRotate : MonoBehaviour
{
    [SerializeField]
    Rigidbody target;
    [SerializeField]
    Transform rotate;
    [SerializeField]
    Transform _base;
    [SerializeField]
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //target.AddForce(target.transform.forward * 10000f);
        rotate.RotateAround(_base.position,Vector3.up, speed * Time.deltaTime);;
    }

    
}
