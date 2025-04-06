using Unity.Cinemachine;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private float jumpingPower = 8f;

    private float horizontal;
    [SerializeField] private bool isGrounded;
    private bool isFacingRight = true;

    private Collider2D platformCollider;

    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask[] groundLayers;

    [SerializeField] private CinemachineCamera cam1;
    [SerializeField] private CinemachineCamera cam2;

    private void Awake()
    {
        if (cam1 != null)
            CamaraManager.SwitchCamera(cam1);
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        isGrounded = IsGrounded();

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
        }

        // Adjust jump high
        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }

        Flip();

        // Duality
        if(Input.GetMouseButton(1))
        {
            if (transform.position.y >= 0f)
            {
                
                transform.position = new Vector3(
                    transform.position.x,
                    transform.position.y - 40,
                    transform.position.z
                    );
                CamaraManager.SwitchCamera(cam2);
            }
            else
            {
                
                transform.position = new Vector3(
                    transform.position.x,
                    transform.position.y + 40,
                    transform.position.z
                    );
                CamaraManager.SwitchCamera(cam1);
            }
        }

        // Set animator variables
        animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.magnitude));
        animator.SetBool("IsGrounded", isGrounded);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }

    private bool IsGrounded()
    {
        foreach (var layer in groundLayers)
        {
            if(Physics2D.OverlapCircle(groundCheck.position, 0.2f, layer))
                return true;
        }

        return false;
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public bool CanAttack() => IsGrounded();
}