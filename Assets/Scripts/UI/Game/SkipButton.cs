using UnityEngine;

public class SkipButton : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (GameData.gameCompleted)
        {
            spriteRenderer.enabled = true;
        }
    }

    private void OnMouseUpAsButton()
    {
        if (GameData.gameCompleted)
        {
            Debug.Log("Pressed button: Skided");
            GameData.launchWall = true;
        }
    }
}
