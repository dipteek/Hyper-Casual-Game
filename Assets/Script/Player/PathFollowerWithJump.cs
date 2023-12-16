using UnityEngine;
using PathCreation;

public class PathFollowerWithJump : MonoBehaviour
{
    public PathCreator pathCreator;
    public GameObject player;

    private float distanceTravelled = 0f;

    public float playerSpeed = 5.0f;

    public float jumpThreshold = 10.0f;
    public bool isJumpFollower = false;

    public float spdincrease = 0f;



    private void Update()
    {
        distanceTravelled += Time.deltaTime * playerSpeed;

        // Ensure the player does not go beyond the path length
        distanceTravelled = Mathf.Clamp(distanceTravelled, 0, pathCreator.path.length);

        if (!isJumpFollower)
        {
            Vector3 newPosition = pathCreator.path.GetPointAtDistance(distanceTravelled);
            //print(newPosition.z);
            player.transform.position = newPosition;
        }

        pathJump();

        

        // Detect when to trigger a jump
        /*if (ShouldJump(distanceTravelled))
        {
            player.GetComponent<PlayerJumpScript>().Jump();
        }*/
        
    }

    public void pathJump(){
        if (isJumpFollower)
        {
            if (spdincrease > 1)
            {
                print(" Yeh Value reach 1"+spdincrease);
                spdincrease = 0;
                isJumpFollower =false;
            }
            spdincrease = spdincrease + 0.0421f;
            Vector3 newPosition = pathCreator.path.GetPointAtDistance(distanceTravelled);
            Debug.Log(" jumping boy");
            player.transform.position = new Vector3(newPosition.x, spdincrease, newPosition.z);

            player.GetComponent<PlayerJumpScript>().Jump();
            Debug.Log(" jumping boy");
            //isJumpFollower =false;
        }
    }

    private bool ShouldJump(float distance)
    {
        // Implement your logic here to determine when the player should jump along the path.
        // You can use distance, time, or other factors to trigger the jump.
        return (distance > jumpThreshold);
    }
}
