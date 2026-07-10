using UnityEngine;

public class ShieldBar : MonoBehaviour
{
    public Sprite Ready;
    public Sprite Charging;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (GameData.onShield)
        {
            spriteRenderer.sprite = Ready;
            float decreaseFactor = Time.deltaTime / GameDifficulty.shieldDuration;
            transform.localScale -= new Vector3(decreaseFactor, 0f, 0f);
        }
        else if (GameData.onShieldCooldown)
        {
            spriteRenderer.sprite = Charging;
            float increaseFactor = Time.deltaTime / GameDifficulty.shieldCooldown;
            transform.localScale += new Vector3(increaseFactor, 0f, 0f);
        }
        else
        {
            spriteRenderer.sprite = Ready;
            transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
        }
    }
}
