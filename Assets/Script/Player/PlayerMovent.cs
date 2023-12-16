using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovent : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    
    [SerializeField] private float limitValue;

     float startPoint;
     /* public  */Rigidbody rb;

     public float jumpForce = 5f;
                Vector2 firstPressPos;
        Vector2 secondPressPos;
        Vector2 currentSwipe;

        public Animator animator;

        [SerializeField] Collider playerCollider;

        [SerializeField] Vector3 vectorOfPlayer;

        private float xValueGet;

    
       bool isJump= false;
      // [SerializeField] SwipeController swipeController;



    
    // Start is called before the first frame update
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    /// 

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //vectorOfPlayer = new Vector3(0.0f,2.0f,0.0f);
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
             MovePlayer();
        }
        
         
        //MoveEasily();
        // if(Input.touchCount > 0){}
       // ComplexMove();
    }

    private void MovePlayer(){
        // Calculate x position and modify it
        // Mobile screen have three value -1,0,1
        // -1 for left
        // 0 for middle
        // 1 for right
        // assumed screen size : width = 1080px, height = 1920px
        float halfScreen = Screen.width / 2;
        float xPos = (Input.mousePosition.x - halfScreen) / halfScreen; 
        //540-540/540 = 0 middle of the screen
        //0-540/540 = -1 left edge of the screen
        //1080-540/540 = 1 right edge of the screen
        float finalXPos = Mathf.Clamp(xPos * limitValue,-limitValue,limitValue);

        //float yPOs =  (Input.mousePosition.y - Screen.height) / Screen.height;
        
        xValueGet = finalXPos;


        playerTransform.localPosition = new Vector3(finalXPos,0,0);
    }

    private void ComplexMove(){
        startPoint = Input.mousePosition.y;

        float halfScreen = Screen.height;
        float yPos = (Input.mousePosition.y - halfScreen) / halfScreen; 
        
        float finalYPos = Mathf.Clamp(yPos * limitValue,-limitValue,limitValue);

        float newYPos = Input.mousePosition.y;
        print(" yPos : "+yPos+" finalPos :"+yPos);
        if(startPoint < yPos){
            print("up work");
        }
    }


       private void MoveEasily(){
        if(Input.touches.Length > 0)
       {
         Touch t = Input.GetTouch(0);
         if(t.phase == TouchPhase.Began)
         {
              //save began touch 2d point
             firstPressPos = new Vector2(t.position.x,t.position.y);
         }
         if(t.phase == TouchPhase.Ended)
         {
              //save ended touch 2d point
             secondPressPos = new Vector2(t.position.x,t.position.y);
                           
              //create vector from the two points
             currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
               
             //normalize the 2d vector
             currentSwipe.Normalize();
 
             //swipe upwards
             if(currentSwipe.y > 0 &&  currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
             {
                 Debug.Log("up swipe");
                 Jump();
             }
             //swipe down
             if(currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
             {
                 Debug.Log("down swipe");
                 slide();
             }
             //swipe left
             if(currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
             {
                 Debug.Log("left swipe");
             }
             //swipe right
             if(currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
             {
                 Debug.Log("right swipe");
             }
         }
        }
        animator.SetTrigger("run");
    }


   


    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Jump(){
        //swipeController.JumpPlayer(); 
        //vectorOfPlayer = new Vector3(xValueGet,2.0f,0.0f);
        //transform.Translate(Vector3.up * jumpForce*Time.deltaTime);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        //print("Before "+rb.velocity.y);
       // rb.AddForce(vectorOfPlayer * jumpForce, ForceMode.Force);  
        //print("After "+rb.velocity.y);
            animator.SetTrigger("jumps");
            //rb.AddForce(Vector3.up * jumpForce, ForceMode.Force); 
            //animator.SetBool("jump", true);
            //animator.SetBool("idle", false);
           //print("jump "+transform.position.y);
           //print(" Before "+rb.velocity.y);
           
           //print(rb.velocity.y);
           isJump = false;
   }

   private void slide(){
                animator.SetTrigger("slide");
                playerCollider.transform.localScale = new Vector3(0.12f, 0.11f, 0.13f); // Adjust the size as needed
                playerCollider.transform.localPosition = new Vector3(0f, -0.25f, 0f); // Adjust the position as needed

   }

    
}
