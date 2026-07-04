using System.Net.NetworkInformation;
using UnityEngine;


public class CloudsMenuMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
 
    private float pixelsPerUnit = 32f;
 
    private Rigidbody2D rb;
 
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
 
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(-1f * moveSpeed, 0f);
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
