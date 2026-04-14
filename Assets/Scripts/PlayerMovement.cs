using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Public Variables
    public float verticalSpeed = 5f;

    // Private Variables
    private Rigidbody2D rb;
    private float verticalInput;
    private float pixelsPerUnit = 32f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
 
    private void Update()
    {
        if (Keyboard.current.wKey.isPressed)
            verticalInput = 1f;
        else if (Keyboard.current.sKey.isPressed)
            verticalInput = -1f;
        else
            verticalInput = 0f;
    }
 
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, verticalInput * verticalSpeed);
    }

    private void LateUpdate()
    {
        SnapToPixel();
    }

    private void SnapToPixel()
    {
        Vector3 pos = transform.position;
 
        pos.x = Mathf.Round(pos.x * pixelsPerUnit) / pixelsPerUnit;
        pos.y = Mathf.Round(pos.y * pixelsPerUnit) / pixelsPerUnit;
 
        transform.position = pos;
    }
}
