using UnityEngine;
using UnityEngine.InputSystem;

public class HungerDuck : MonoBehaviour
{

    public InputAction moveKeys;
    Rigidbody2D rb;
    int velocity = 5;
    public GameObject sprite;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        var direction = moveKeys.ReadValue<float>();
        if (direction != 0)
        {
            rb.linearVelocity = new Vector2 (direction * velocity,rb.linearVelocityY);
        }     
    }

    void OnEnable()
    {
        moveKeys.Enable();
    }

    void OnDisable()
    {
        moveKeys.Disable();
    }
}
