using UnityEngine;
using UnityEngine.InputSystem;

public class catBehavior : MonoBehaviour
{
    [SerializeField] private float throwMult = 1f;
    private Rigidbody2D rb;
    private Collider2D col;
    private Vector2 MousePos;
    private Vector2 mouseVelocity;
    private bool dragging = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
        if (Mouse.current.leftButton.isPressed)
        {
            Collider2D hit = Physics2D.OverlapPoint(MousePos);
            if (hit == col)
            {
                dragging = true;
            }
            if (dragging)
            {
                mouseVelocity = Mouse.current.delta.ReadValue();
            }
        }
        if (dragging && Mouse.current.leftButton.wasReleasedThisFrame)
        {
            dragging = false;
            rb.linearVelocity = mouseVelocity * throwMult;
        }
    }
    void FixedUpdate()
    {
        if (dragging)
        {
            rb.MovePosition(MousePos);
            rb.linearVelocity = Vector2.zero;
        }
    }
}
