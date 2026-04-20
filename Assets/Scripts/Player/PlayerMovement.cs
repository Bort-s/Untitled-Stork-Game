using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;
using Debug = UnityEngine.Debug;

public class PlayerMovement : MonoBehaviour
{
    // Vertical Speed
    private float maxVerticalSpeed = 8f;
    private float verticalAcceleration = 25f;

    private float targetSpeed;
    private float currentVerticalSpeed;

    // Else
    private Rigidbody2D rb;
    private float verticalInput;
    private float pixelsPerUnit = 32f;

    // Speed Control

    private float acceleration = 0.08f;
    private float maxSpeed = 5f;


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

        if (Keyboard.current.dKey.isPressed && Keyboard.current.aKey.isPressed)
        {
            
        }
        else if (Keyboard.current.aKey.isPressed)
        {
            if (GameData.speed > 1f) 
                GameData.speed -= acceleration;
                Debug.Log("New Speed: " + GameData.speed);
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            if (GameData.speed < maxSpeed) 
                GameData.speed += acceleration;
                Debug.Log("New Speed: " + GameData.speed);
        }

    }
 
    private void FixedUpdate()
    {
        targetSpeed = verticalInput * maxVerticalSpeed;

        if (verticalInput == 0)
            currentVerticalSpeed = 0f;
        else if (currentVerticalSpeed != 0f && Mathf.Sign(verticalInput) != Mathf.Sign(currentVerticalSpeed))
            currentVerticalSpeed = 0f;
        else
            currentVerticalSpeed = Mathf.MoveTowards(currentVerticalSpeed, targetSpeed, verticalAcceleration * Time.fixedDeltaTime);
        
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, currentVerticalSpeed);
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
