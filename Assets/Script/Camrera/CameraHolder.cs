using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private Vector3 initialRotation;
     public bool isJumpOfCameraFollower = false;

     int playerSelecter;

     public GameObject gameObject;


     /// <summary>
     /// Start is called on the frame when a script is enabled just before
     /// any of the Update methods is called the first time.
     /// </summary>
     void Start()
     {
        playerSelecter =  PlayerPrefs.GetInt("selectedCharater");
        if (playerSelecter == 0)
        {
            gameObject = GameObject.Find("Players/Breathing Idle1");//
        }else if (playerSelecter == 1)
        {
            gameObject = GameObject.Find("Players/untitlemixama3");//untitlemixama3
        }else
        {
            gameObject = GameObject.Find("Players/Breathing Idle1");
        }
        playerTransform = gameObject.transform;
     }
    

    private void Awake() {
        initialRotation = transform.eulerAngles;
    }
    
    private void Update() {
        if(isJumpOfCameraFollower){
            transform.position = new Vector3(playerTransform.position.x,0,playerTransform.position.z);
            transform.eulerAngles = new Vector3(playerTransform.eulerAngles.x + initialRotation.x,playerTransform.eulerAngles.y  +initialRotation.y,0);

        }else{
           transform.position = new Vector3(playerTransform.position.x,0,playerTransform.position.z);
            transform.eulerAngles = new Vector3(playerTransform.eulerAngles.x + initialRotation.x,playerTransform.eulerAngles.y  +initialRotation.y,0);
            // playerTransform.position.y
        }
    }
    // Start is called before the first frame update
    
}
