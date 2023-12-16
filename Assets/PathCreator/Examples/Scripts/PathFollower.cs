using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
         public float speedWhenJump = 6;
        float distanceTravelled;

        public bool isJumpFollower = false;
        public bool isJumpFollowerCompleted = false;

         public bool isAdvJumpFollowerCompletedAdv = false;

        float saveDistanceTravelledTime;

        [SerializeField] Transform playerTransform;
        Rigidbody rigidbody;

        public FixedTouchField fixedTouchField;


           public float spdincrease = 0f;
           protected float spdDrecrease;

           [SerializeField] GameManager gameManager;

            [SerializeField] private float limitValue;
           private float finalXPos;

        void Start() {
            rigidbody = GetComponent<Rigidbody>();
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }
        }

        void Update()
        {
            if (gameManager.isGameStart && gameManager.gameDefeat == false)
            {
                if (pathCreator != null)
                {
                    distanceTravelled += speed * Time.deltaTime;

                    pathJump();

                    if (!isAdvJumpFollowerCompletedAdv)
                    {
                        float halfScreen = Screen.width /2.3f ; //2.3f
                        float xPos = (fixedTouchField.TouchDistx - halfScreen) / halfScreen; 
                        //540-540/540 = 0 middle of the screen
                        //0-540/540 = -1 left edge of the screen
                        //1080-540/540 = 1 right edge of the screen
                        //print(xPos);
                        finalXPos = Mathf.Clamp(xPos * limitValue,-limitValue,limitValue);
                        
                        Vector3 temp;

                        Vector3 newPosition = pathCreator.path.GetPointAtDistance(distanceTravelled);
                        temp = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                        //print(newPosition.z);
                        transform.position = new Vector3(finalXPos,temp.y,temp.z);
                        //transform.position = newPosition;
                    }

                    
                    
                    /*if (isJumpFollower)
                    {
                        Debug.Log(isJumpFollower);
                        
                            //transform.position = new Vector3(tempPosition.x,4,tempPosition.z);

                    }else{
                        if (isJumpFollowerCompleted)
                        {
                            
                        }
                        
                    }*/
                    
                    transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
                    transform.eulerAngles += new Vector3(0,0,90);
                }
            }
            
            //ifPlayerJump();
        }

        public void ifPlayerJump(){
            if (pathCreator != null)
            {
                distanceTravelled += speed * Time.deltaTime;
                if (!isJumpFollower && !isJumpFollowerCompleted)
                {
                    transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
               
                    //Debug.Log(isJumpFollower);
                    
                    //rigidbody.AddForce(Vector3.forward * speedWhenJump, ForceMode.Impulse);
                    
                   // Vector3 tempPosition = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                    //transform.position = new Vector3(tempPosition.x,4,tempPosition.z);

                }else{
                    /*if (isJumpFollowerCompleted)
                    {
                        
                    }*/
                     }
                
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
                transform.eulerAngles += new Vector3(0,0,90);
            }
        }

         public void pathJump(){
            if (isAdvJumpFollowerCompletedAdv)
            {
                
                if (isJumpFollower)
                {
                    if (spdincrease > 1)
                    {
                        //print(" Yeh Value reach "+spdincrease);
                        //spdincrease = 0;
                        //isJumpFollowerCompleted = true;
                        isJumpFollower =false;
                        
                    }
                    spdincrease = spdincrease + 0.0421f;
                    

                    //player.GetComponent<PlayerJumpScript>().Jump();
                    //Debug.Log(" jumping boy");
                    //isJumpFollower =false;
                }else{
                    if (isJumpFollowerCompleted)
                    {
                        
                        if (spdincrease < 0)
                        {
                           // print(" Yeh Value reach reduce "+spdincrease);
                            spdincrease = 0;
                            isJumpFollowerCompleted =false;
                            isAdvJumpFollowerCompletedAdv = false;
                        }
                    spdincrease = spdincrease - 0.0991f;
                    /*Vector3 newPosition = pathCreator.path.GetPointAtDistance(distanceTravelled);
                    Debug.Log(" jumping ground");
                    transform.position = new Vector3(newPosition.x, spdincrease, newPosition.z);*/
                    }
                    
                }
                 float halfScreen = Screen.width /2.3f ;
                float xPos = (fixedTouchField.TouchDistx - halfScreen) / halfScreen; 
                //540-540/540 = 0 middle of the screen
                //0-540/540 = -1 left edge of the screen
                //1080-540/540 = 1 right edge of the screen
                print(xPos);
                finalXPos = Mathf.Clamp(xPos * limitValue,-limitValue,limitValue);
                Vector3 newPosition = pathCreator.path.GetPointAtDistance(distanceTravelled);
                    //Debug.Log(" jumping boy");
                    transform.position = new Vector3(finalXPos, spdincrease, newPosition.z);
            }
    }

        

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
    }
}