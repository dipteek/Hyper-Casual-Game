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

     [SerializeField] FixedTouchField fixedTouchField;
    float currentSpeed = 0f;
    public float smoothingFactor = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        jumpButton.gameObject.SetActive(false);
        slideButton.gameObject.SetActive(false);
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

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        
        if (FindObjectOfType<GameManager>().isGameStart)
        {
            jumpButton.gameObject.SetActive(true);
            slideButton.gameObject.SetActive(true);
             // SMOOTH HORIZONTAL MOVEMENT BASED ON TOUCH
            float moveAmount = fixedTouchField.TouchDist.x * Time.deltaTime;
            currentSpeed = Mathf.Lerp(currentSpeed, moveAmount, smoothingFactor);
            gameObject.transform.Translate(Vector3.right * currentSpeed);
        }

      
       if (FindObjectOfType<GameManager>().gameLevelFinished)
        {
            jumpButton.gameObject.SetActive(false);
            slideButton.gameObject.SetActive(false);
        }


    }

    

    public void Jump(){
                    FindObjectOfType<SoundManagerPlay>().playJumpSFX();
                    jumpButton.enabled = false;
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

    // private IEnumerator DelayedForGround(){
    //     yield return new WaitForSeconds(0.31f);
    //     jumpButton.enabled = true;
    //     //pathFollower.isJumpFollower = false;
    //     animator.SetTrigger("run");
    //     pathFollower.isJumpFollowerCompleted =false;
    //     cameraHolder.isJumpOfCameraFollower = false;
    //                     pathFollower.isAdvJumpFollowerCompletedAdv =false;
    //                     pathFollower.isJumpFollower =false;
    //   animator.SetTrigger("run");
    // }

    private IEnumerator DelayedForGround()
    {
        yield return new WaitForSeconds(0.31f);
        jumpButton.enabled = true;
        
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Jump")) 
        {
            yield return new WaitForSeconds(0.2f); // Wait a bit more if still jumping
        }

        animator.SetTrigger("run");
        pathFollower.isJumpFollowerCompleted = false;
        cameraHolder.isJumpOfCameraFollower = false;
        pathFollower.isAdvJumpFollowerCompletedAdv = false;
        pathFollower.isJumpFollower = false;
    }




    public void slide(){
                slideButton.enabled = false;
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
        slideButton.enabled = true;
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



