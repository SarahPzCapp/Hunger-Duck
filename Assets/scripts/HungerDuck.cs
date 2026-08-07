
using UnityEngine;
using UnityEngine.InputSystem;

public class HungerDuck : MonoBehaviour
{
    public InputAction moveKeys;
    public InputAction jumpAction; // novo InputAction para o pulo
    Rigidbody2D rb;
    int velocity = 5;
    public SpriteRenderer sprite;
    bool chaoEsta;
    Transform groundcheck;
    public LayerMask chaoPlayer;
    bool isJumping;
    float jumpForce = 10f;

    void Awake()
    {
        groundcheck = GameObject.Find("groundcheck").transform;
        rb = GetComponent<Rigidbody2D>();
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        moveKeys.Enable();
        jumpAction.Enable();
    }

    void OnDisable()
    {
        moveKeys.Disable();
        jumpAction.Disable();
    }

    void Update()
    {
        Movement();
        Turn();

        // Lê o pulo pelo InputAction
        if (jumpAction.WasPressedThisFrame() && chaoEsta)
        {
            isJumping = true;
        }

        // Pulo curto (release)
        if (jumpAction.WasReleasedThisFrame() && rb.linearVelocity.y > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.2f);
        }
    }

    void FixedUpdate()
    {
        Groundcheck();
        Jump();
    }

    void Jump()
    {
        if (isJumping)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isJumping = false;
        }
    }

    void Movement()
    {
        var direction = moveKeys.ReadValue<float>();
        if (direction != 0)
        {
            rb.linearVelocity = new Vector2(direction * velocity, rb.linearVelocity.y);
        }
    }

    void Turn()
    {
        var direction = moveKeys.ReadValue<float>();
        if (direction < 0)
            sprite.flipX = true;
        else if (direction > 0)
            sprite.flipX = false;
    }

    void Groundcheck()
    {
        chaoEsta = Physics2D.Linecast(groundcheck.position, transform.position, chaoPlayer);
    }
}