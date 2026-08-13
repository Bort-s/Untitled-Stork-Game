using UnityEngine;
using System.Collections;

public class BabyAnim : MonoBehaviour
{
    private bool hasStarted = false;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (GameData.gameCompleted)
        {
            if (!hasStarted)
            {
                StartCoroutine(WinAnim());
                hasStarted = true;
            }
        }
    }

    private IEnumerator WinAnim()
    {
        yield return new WaitForSeconds(10f);
        rb.gravityScale = 1f;
        spriteRenderer.enabled = true;
    }
}
