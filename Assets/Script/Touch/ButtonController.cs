using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public PathFollower pathFollower;
    Rigidbody rb;
    public Animator animator;
    [SerializeField] CameraHolder cameraHolder;

    public CapsuleCollider playerCollider;

     int playerSelecter;



     public GameObject gameObject;

     public Button jumpButton;
     
     public Button slideButton;

     public Receiver recevier;

     private Vector3 colliderTempPositionHold;
    
    // Start is called before the first frame update
    void Start()
    {
        playerSelecter =  PlayerPrefs.GetInt("selectedCharater");
        if (playerSelecter == 0)
        {
            gameObject = GameObject.Find("Players/Breathing Idle1");
            animator = gameObject.GetComponent<Animator>();
            pathFollower = gameObject.GetComponent<PathFollower>();
            playerCollider = gameObject.GetComponent<CapsuleCollider>();
            //jumpButton.onClick.AddListener();
            jumpButton?.onClick.AddListener(() => Jump());
            slideButton?.onClick.AddListener(() => slide());
        }else if(playerSelecter == 1)
        {
            gameObject = GameObject.Find("Players/untitlemixama3");
            animator = gameObject.GetComponent<Animator>();
            pathFollower = gameObject.GetComponent<PathFollower>();
            playerCollider = gameObject.GetComponent<CapsuleCollider>();
            jumpButton?.onClick.AddListener(() => Jump());
            slideButton?.onClick.AddListener(() => slide());
        }else{
            gameObject = GameObject.Find("Players/Breathing Idle1");
            animator = gameObject.GetComponent<Animator>();
           pathFollower = gameObject.GetComponent<PathFollower>();
            playerCollider = gameObject.GetComponent<CapsuleCollider>();
            jumpButton?.onClick.AddListener(() => Jump());
            slideButton?.onClick.AddListener(() => slide());
        }
        rb = GetComponent<Rigidbody>();
        //pathFollower = GetComponent<PathFollower>();
        //animator = GetComponent<Animator>();
        
    }

    

    public void Jump(){
                    FindObjectOfType<SoundManagerPlay>().playJumpSFX();
                    if (!pathFollower.isAdvJumpFollowerCompletedAdv)
                    {
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
    }





    private IEnumerator Delayed(){
        yield return new WaitForSeconds(0.8f);
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
        yield return new WaitForSeconds(0.31f);
        //pathFollower.isJumpFollower = false;
        animator.SetTrigger("run");
        pathFollower.isJumpFollowerCompleted =false;
        cameraHolder.isJumpOfCameraFollower = false;
    }



    public void slide(){
                FindObjectOfType<SoundManagerPlay>().playSlideSFX();
                colliderTempPositionHold = playerCollider.center;
                animator.SetTrigger("slide");
                 //animator.SetBool("slideb",true);
                // yes playerCollider.transform.localScale = new Vector3(0.12f, 0.11f, 0.13f); // Adjust the size as needed
                playerCollider.transform.localPosition = new Vector3(0f, -0.25f, 0f); // Adjust the position as needed
                //animator.SetBool("slideb",false);
                playerCollider.direction = 2;
                playerCollider.center =new Vector3(0.004740089f,0.36f,0);
                StartCoroutine(DelayedForSlide());
                //animator.SetTrigger("run");
                //animator.SetBool("runb",true);

   }

   private IEnumerator DelayedForSlide(){
        yield return new WaitForSeconds(1.0f);
        //pathFollower.isJumpFollower = false;
        //animator.SetBool("slideb",false);
        //animator.SetBool("runb",true);
        animator.SetTrigger("run");
        playerCollider.direction = 1;
        playerCollider.center = colliderTempPositionHold;
        //playerCollider.center =new Vector3(0.004740089f,0.9096543f,0);
        
    }


   public void dance(){
                animator.SetTrigger("dance");
   }


   




}



