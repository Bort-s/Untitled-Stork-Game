using UnityEngine;

public class SetTime : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRendererUnit;
    [SerializeField] private SpriteRenderer spriteRendererTen;
    [SerializeField] private SpriteRenderer spriteRendererHundred;
    [SerializeField] private Sprite[] numbers;

    public void PutTime(int score)
    {
        int hundred = Mathf.FloorToInt(score / 100f);
        int ten = Mathf.FloorToInt(score / 10f) - (hundred * 10);
        int unit = score - (Mathf.FloorToInt(score / 10f) * 10);

        spriteRendererUnit.sprite = numbers[unit];
        spriteRendererTen.sprite = numbers[ten];
        spriteRendererHundred.sprite = numbers[hundred];
    }
}
