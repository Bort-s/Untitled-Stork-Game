using UnityEngine;

public class StarRating : MonoBehaviour
{
    public float starNumber;

    public Sprite star;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() 
    {
        if (starNumber <= WinData.stars)
        {
            spriteRenderer.sprite = star;
        }
    }
}
