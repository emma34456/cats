using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class catBehavior : MonoBehaviour
{
    [SerializeField] private float throwMult = 1f;
    [SerializeField] private float maxStamina = 5f;
    private float stamina;
    public Image staminaBar;
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
        stamina = maxStamina;
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
                stamina -= Time.deltaTime;
                if (stamina <= 0f)
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
            rb.MovePosition(MousePos);
            rb.linearVelocity = Vector2.zero;
        }
    }
}
