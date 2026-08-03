using UnityEngine;

public class BabySprite : MonoBehaviour
{
    public Sprite[] babySprite;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (WinData.stars != 0)
            spriteRenderer.sprite = babySprite[(WinData.stars - 1)];
    }
}
