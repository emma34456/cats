using UnityEngine;
using UnityEngine.UIElements;

public class cameraBehavior : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 5f;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector2 min;
    [SerializeField] private Vector2 max;
    void LateUpdate()
    {
        Vector3 position = target.position + offset;
        position.x = Mathf.Clamp(position.x, min.x, max.x);
        position.y = Mathf.Clamp(position.y, min.y, max.y);
        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * speed);
    }
}
