using System.Diagnostics;
using System.Collections;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class ShieldAnim : MonoBehaviour
{
    public Sprite Normal;
    public Sprite Broken;

    private Animator animator;
    private bool hasBeenTriggered = false;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameData.onShield && !hasBeenTriggered)
        {
            hasBeenTriggered = true;
            StartCoroutine(StartAnimator());
        }

        if (GameData.onShieldCooldown)
        {
            spriteRenderer.sprite = Broken;
        }
        else
        {
            spriteRenderer.sprite = Normal;
        }

        if (GameData.gameCompleted)
        {
            Vector3 newPosition = new Vector3(transform.position.x, 4f, 0f);
            transform.position = Vector3.MoveTowards(transform.position, newPosition, 4f * Time.deltaTime);
        }
    }

    private IEnumerator StartAnimator()
    {
        yield return new WaitForSeconds(GameDifficulty.shieldDuration);
        animator.SetTrigger("BreakShield");
        hasBeenTriggered = false;
    }
}
