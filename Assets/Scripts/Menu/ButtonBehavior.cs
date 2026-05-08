using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class ButtonBehavior : MonoBehaviour
{
    public int buttonIndex;

    private bool isPressed = false;
    private bool isHovering = false;
    private bool isReleased = false;

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
        isReleased = false;
    }

    void OnMouseUp()   
    {
        isReleased = true;
        isPressed = false;
    }

    void OnMouseExit() 
    {
        isHovering = false;
    }

    void OnMouseUpAsButton()
    {
        if (isReleased)
        {
            switch (buttonIndex)
            {
                case 0:
                    PlayButton();
                    break;
                case 1:
                    TutorialButton();
                    break;
                case 2:
                    AchievementsButton();
                    break;
                case 3:
                    CreditsButton();
                    break;
                case 4:
                    ExitButton();
                    break;
                default:
                    Debug.LogWarning("Invalid button index: " + buttonIndex);
                    break;
            }
        }
        isPressed = false;
        isReleased = false;
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void TutorialButton()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void AchievementsButton()
    {
        SceneManager.LoadScene("Achievements");
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ExitButton()
    {
        Application.Quit();
 
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    void Update()
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
}
