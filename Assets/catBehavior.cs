using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class catBehavior : MonoBehaviour
{
    [SerializeField] private float throwMult = 1f;
    [SerializeField] private float maxStamina = 5f;
    [SerializeField] private float maxDragSpeed = 10f;
    private float stamina;
    public Image staminaBar;
    private Rigidbody2D rb;
    private Collider2D col;
    private Vector2 mousePos;
    private Vector2 lastMousePos;
    private Vector2 mouseVelocity;
    private bool dragging = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        stamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
        if (Mouse.current.leftButton.isPressed)
        {
            Collider2D hit = Physics2D.OverlapPoint(mousePos);
            if (hit == col)
            {
                dragging = true;
                lastMousePos = mousePos;
            }
            if (dragging)
            {
                mouseVelocity = (mousePos - lastMousePos) / Time.deltaTime;
                stamina -= Time.deltaTime;
                if (stamina <= 0f)
                {
                    dragging = false;
                }
                if (mouseVelocity.magnitude > maxDragSpeed)
                {
                    dragging = false;
                }
            }
        }
        if (dragging && Mouse.current.leftButton.wasReleasedThisFrame)
        {
            dragging = false;
            rb.linearVelocity = mouseVelocity * throwMult;
        }
        if (!dragging && stamina < maxStamina)
        {
            stamina += Time.deltaTime;
        }
        else if (stamina > maxStamina)
        {
            stamina = maxStamina;
        }
        staminaBar.fillAmount = stamina / maxStamina;
    }
    void FixedUpdate()
    {
        if (dragging)
        {
            rb.MovePosition(mousePos);
            rb.linearVelocity = Vector2.zero;
            
        }
    }
}
