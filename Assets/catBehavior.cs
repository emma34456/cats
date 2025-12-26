using UnityEngine;
using UnityEngine.InputSystem;

public class catBehavior : MonoBehaviour
{
    Vector3 offset;
    private Vector3 MousePos()
    {
        return Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            transform.position = MousePos();
        }
    }
}
