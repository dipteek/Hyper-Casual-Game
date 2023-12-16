using UnityEngine;

public class PlayerJumpScript : MonoBehaviour
{
    public float jumpForce = 5.0f;
    public float runForce = 2.0f;
    public float jumpDelay = 2.0f; // Time delay before jumping

    private Rigidbody rb;
    private float jumpTimer = 0f;
    private bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isJumping)
        {
            jumpTimer += Time.deltaTime;

            if (jumpTimer >= jumpDelay)
            {
                Jump();
            }
        }
    }

    public void Jump()
    {
        if (!isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            rb.AddForce(Vector3.up * runForce, ForceMode.Impulse);
            jumpTimer = 0f;
            isJumping = true;
        }
    }
}
