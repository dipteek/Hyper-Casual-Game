using System.Collections;
using System.Collections.Generic;
using PathCreation.Examples;
using UnityEngine;

public class Test : MonoBehaviour
{
    Rigidbody rb;
    float jumpForce = 5;

    [SerializeField] private Transform playerTransform;
    
    [SerializeField] private float limitValue;

    
       Vector2 firstPressPos;
        Vector2 secondPressPos;
        Vector2 currentSwipe;

        PathFollower pathFollower;
        PathFollowerWithJump pathFollowerWithJump;
        [SerializeField] CameraHolder cameraHolder;

         private Animator animator;
         private Collider playerCollider;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pathFollower = GetComponent<PathFollower>();
        pathFollowerWithJump = GetComponent<PathFollowerWithJump>();
        animator = GetComponent<Animator>();
        playerCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
        MoveEasily(); 
        MovePlayer();
    }


     private void MoveEasily(){
        if(Input.touches.Length > 0)
       {
        
              float halfScreen = Screen.width / 2;
           float xPos = (Input.mousePosition.x - halfScreen) / halfScreen; 
             if(xPos < 1.4f){
                MovePlayer();
             }
        /*if (true)
        {
            
        }*/
         Touch t = Input.GetTouch(0);
         if(t.phase == TouchPhase.Began)
         {
              //save began touch 2d point\
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

             bool isRigid = false;

             print(currentSwipe.y);
 
             //swipe upwards
             if(currentSwipe.y > 0.9999999999f &&  currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
             {
                 Debug.Log("up swipe");
                    if (!pathFollower.isAdvJumpFollowerCompletedAdv)
                    {
                        isRigid = true;
                    //pathFollower.isJumpFollower = true;
                    animator.SetTrigger("jumps");
                    cameraHolder.isJumpOfCameraFollower = true;
                    pathFollower.isAdvJumpFollowerCompletedAdv =true;
                    cameraHolder.isJumpOfCameraFollower = true;
                    pathFollower.isJumpFollower =true;
                    pathFollower.pathJump();
                    
                    
                    //pathFollower.ifPlayerJump();
                    
                    //rb.AddForce(Vector3.forward * jumpForce, ForceMode.Impulse);
                   

                    /*if (isRigid)
                    {
                        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                        isRigid = false;
                    }*/
                    //pathFollowerWithJump.spdincrease = 0;

                    StartCoroutine(Delayed());

                    
                    }
                 
                 //Jump();
             }
             //swipe down
             if(currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
             {
                if (!pathFollower.isAdvJumpFollowerCompletedAdv)
                {
                    slide();
                    Debug.Log("down swipe");
                    animator.SetTrigger("run");
                }
                 
             }
             //swipe left
             if(currentSwipe.x < 0  && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
             {
                 Debug.Log("left swipe");
                 
             }/*else if(){
                
             }*/
             //swipe right
             if(currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
             {
                 Debug.Log("right swipe");
                 
             }
         }
        }
       // animator.SetTrigger("run");
    }

    private IEnumerator Delayed(){
        yield return new WaitForSeconds(1.0f);
        //pathFollower.isJumpFollower = false;
        pathFollower.isJumpFollower =false;
        pathFollower.pathJump();
        
        //cameraHolder.isJumpOfCameraFollower = false;

        //cameraHolder.isJumpOfCameraFollower = true;
                pathFollower.isJumpFollowerCompleted =true;
                //pathFollower.pathJump();
                cameraHolder.isJumpOfCameraFollower = true;
                StartCoroutine(DelayedForGround());
    }

    private IEnumerator DelayedForGround(){
        yield return new WaitForSeconds(0.61f);
        //pathFollower.isJumpFollower = false;
        animator.SetTrigger("run");
        pathFollower.isJumpFollowerCompleted =false;
        cameraHolder.isJumpOfCameraFollower = false;
    }

    private void slide(){
                animator.SetTrigger("slide");
                playerCollider.transform.localScale = new Vector3(0.12f, 0.11f, 0.13f); // Adjust the size as needed
                playerCollider.transform.localPosition = new Vector3(0f, -0.25f, 0f); // Adjust the position as needed

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
        //print(xPos);

        //float yPOs =  (Input.mousePosition.y - Screen.height) / Screen.height;
        
       // xValueGet = finalXPos;


        playerTransform.localPosition = new Vector3(finalXPos,-0.8649288f,0);
    }
    

}
