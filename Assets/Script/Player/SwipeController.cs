using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;
    private float minSwipeDistance = 20f;
    bool isJump= false;
     Animator animator;
     Rigidbody rb;

     public float jumpForce = 2f;

     bool slide =false;
     public Collider playerCollider;

      Vector2 startPoint, endPoint;

      



     /// <summary>
     /// Start is called on the frame when a script is enabled just before
     /// any of the Update methods is called the first time.
     /// </summary>
     void Start()
     {
         animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
     }

    private void Update()
    {
        //HandleInput();
        playerController();
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        
    }

    private void playerController(){
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

        if (endPoint.y < startPoint.y)
        {
            print("slde");
                slide = true;
                GetComponent<Animator>().SetTrigger("slide");
                playerCollider.transform.localScale = new Vector3(0.12f, 0.11f, 0.13f); // Adjust the size as needed
                playerCollider.transform.localPosition = new Vector3(0f, -0.25f, 0f); // Adjust the position as needed

            endPoint = Vector2.zero;
            startPoint = Vector2.zero;
        }


        if (endPoint.y > startPoint.y && rb.linearVelocity.y ==0)
        {
            isJump = true;
                // Up swipe
                // Implement your up movement logic here
                
                    
                    
                    if(isJump){
                        // animator.SetBool("jump", false);
                        Jump();
                         //isJump = false;
                    }
        }

        if (slide)
        {
            print("run start");
            GetComponent<Animator>().SetTrigger("run");
            slide = false;
        }

    }

    private void HandleInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                fingerDownPosition = touch.position;
                fingerUpPosition = touch.position;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                fingerUpPosition = touch.position;
                CheckSwipe();
            }
        }
    }

    private void CheckSwipe()
{

    
    float swipeDistanceX = Mathf.Abs(fingerUpPosition.x - fingerDownPosition.x);
    float swipeDistanceY = Mathf.Abs(fingerUpPosition.y - fingerDownPosition.y);

    if (swipeDistanceX > minSwipeDistance || swipeDistanceY > minSwipeDistance)
    {
        if (swipeDistanceX > swipeDistanceY)
        {
            // Horizontal swipe detected
            if (fingerUpPosition.x > fingerDownPosition.x)
            {
                // Right swipe
                // Implement your right movement logic here
            }
            else
            {
                // Left swipe
                // Implement your left movement logic here
            }
        }
        else
        {
            // Vertical swipe detected
            if (fingerUpPosition.y > fingerDownPosition.y && rb.linearVelocity.y == 0)
            {
                isJump = true;
                // Up swipe
                // Implement your up movement logic here
                
                //GetComponent<Animator>().SetTrigger("jump");
                /*if (transform.position.y < 0.2)
                {*/
                    
                    
                    if(isJump){
                        // animator.SetBool("jump", false);
                        Jump();
                         //isJump = false;
                    }

                //}
                
                
                
            }else if (fingerUpPosition.y < fingerDownPosition.y && rb.linearVelocity.y == 0){
                print("slde");
                slide = true;
                GetComponent<Animator>().SetTrigger("slide");
                playerCollider.transform.localScale = new Vector3(0.12f, 0.11f, 0.13f); // Adjust the size as needed
                playerCollider.transform.localPosition = new Vector3(0f, -0.25f, 0f); // Adjust the position as needed

            }
            else
            {
               /* print("slide");
                // Down swipe
                // Implement your down movement logic here
                slide = true;
                GetComponent<Animator>().SetTrigger("slide");
                playerCollider.transform.localScale = new Vector3(0.12f, 0.11f, 0.13f); // Adjust the size as needed
                //playerCollider.transform.localPosition = new Vector3(0f, -0.25f, 0f); // Adjust the position as needed

        */
                
            }
            
        }
    }

    print("near run after slide");
    if (slide)
    {
        print("run start");
        GetComponent<Animator>().SetTrigger("run");
        slide = false;
    }
    
    if(rb.linearVelocity.y == 0){
        //print("jump false");
        GetComponent<Animator>().SetTrigger("run");
                   // animator.SetBool("jump", false);
                    //animator.SetBool("idle", true);
    }
}

   private void Jump(){
            GetComponent<Animator>().SetTrigger("jumps");
            //animator.SetBool("jump", true);
            //animator.SetBool("idle", false);
           print("jump "+transform.position.y);
           print(" Before "+rb.linearVelocity.y);
           rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);  
           print(rb.linearVelocity.y);
           isJump = false;
   }

   public void JumpPlayer(){
    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);  
   }




 
}
