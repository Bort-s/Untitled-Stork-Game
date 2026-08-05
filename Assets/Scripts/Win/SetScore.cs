using UnityEngine;

public class SetScore : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRendererUnit;
    [SerializeField] private SpriteRenderer spriteRendererTen;
    [SerializeField] private Sprite[] numbers;

    public void PutScore(int score)
    {
        int ten = Mathf.FloorToInt(score / 10f);
        int unit = score - (ten * 10);

        spriteRendererUnit.sprite = numbers[unit];
        spriteRendererTen.sprite = numbers[ten];
    }
}
