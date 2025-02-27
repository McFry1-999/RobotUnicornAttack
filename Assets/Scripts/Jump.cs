using UnityEngine;

public class Jump : MonoBehaviour
{
   [SerializeField]

   public float jumpForce = 10f;

    [SerializeField]
    private float maxJumpTime = 0.3f;

    [SerializeField]
    private float jumpBoost = 0.5f;

    private Rigidbody rb;
    private bool isGrounded;
    private bool isJumping;
    private float JumptimeCounter;
    private bool buttonpressed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void StartJump()
    {
        buttonpressed = true;
        if (isGrounded)
        {
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
            isGrounded = true;
        }
    }
}