using UnityEngine;

public class ButtonState : MonoBehaviour
{
    public bool isActive;
    private bool isPressed = false;
    private bool isHovering = false;

    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void OnMouseOver() 
    {
        isHovering = true;
    }

    void OnMouseDown()  
    {
        isPressed = true;
    }

    void OnMouseUp()   
    {
        isPressed = false;
    }

    void OnMouseExit() 
    {
        isHovering = false;
    }

    void Update()
    {
        if (isActive)
        {
            if (isPressed)
            {
                sprite.color = Color.gray;
            }
            else if (isHovering)
            {
                sprite.color = new Color(0.8f, 0.8f, 0.8f);
            }
            else
            {
                sprite.color = Color.white;
            }
        }
        else
        {
            sprite.color = Color.gray;
        }
    }
}
