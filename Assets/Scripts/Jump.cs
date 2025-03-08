using UnityEngine;

public class Jump : MonoBehaviour
{
   [SerializeField]

   public float jumpForce = 10f;

    [SerializeField]
    private float maxJumpTime = 0.3f;

    [SerializeField]
    private float jumpBoost = 0.5f;

    [SerializeField]
    private int maxJumps = 2;

    private int Jumps;

    private Rigidbody rb;
    private bool isGrounded;
    private bool isJumping;
    private float JumptimeCounter;
    private bool buttonpressed;

    private bool canJump = true;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetCanJump(bool value)
    {
        canJump = value;
    }

    private void RestartJumps()
    {
        Jumps = maxJumps;
    }

    public void StartJump()
    {

        if(!canJump)
        {
            return;
        }
        buttonpressed = true;
        if (isGrounded || Jumps > 0)
        {
            Jumps --;
            isJumping = true;
            JumptimeCounter = maxJumpTime;
            rb.linearVelocity = Vector3.up * jumpForce;
            isGrounded = false;
        }
    }

    public void EndJump()
    {
        buttonpressed = false;
        isJumping =  false;
    }

    private void FixedUpdate()
    {
        HandleJump();
    }

    private void HandleJump()
    {
        if(buttonpressed && isJumping)
        {
            if(JumptimeCounter > 0)
            {
                rb.linearVelocity = Vector3.up * (jumpForce + jumpBoost);
                JumptimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            RestartJumps();
            isGrounded = true;
        }
    }
}