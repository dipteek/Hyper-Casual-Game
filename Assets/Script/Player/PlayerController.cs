using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 252f;
    private bool isGrounded;
    public Rigidbody rb;

    Vector2 startPoint, endPoint;
    bool isJump;
     Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        Debug.Log(" hii play ");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startPoint = Input.GetTouch(0).position;
            
            //if(Input.GetMouseButton(0)){
           
            //}
        }

        /*if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            //startPoint = Input.GetTouch(0).position;
            //if(Input.GetMouseButton(0)){
            MovePlayer();
            //}
        }*/


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endPoint = Input.GetTouch(0).position;
        }

        if (endPoint.y > startPoint.y && rb.linearVelocity.y ==0)
        {
            print("is true");
           
            isJump = true;
            playerAnimator.SetBool("jump", true);
            endPoint = Vector2.zero;
            startPoint = Vector2.zero;
        }

        
    }

    public void PlayerJump(){
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        if (isJump)
        {
            //print(" Yeah, You call jump to player");
            //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            rb.AddForce(Vector3.up * jumpForce);
            
            isJump = false;
            if(rb.linearVelocity.y == 0){
                
            }
            playerAnimator.SetBool("jump", false);
        }
    }
}
