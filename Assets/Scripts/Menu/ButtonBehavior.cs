using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class ButtonBehavior : MonoBehaviour
{
    public GameObject wall = null;
    public int buttonIndex;
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

    void OnMouseUpAsButton()
    {
        if (isActive)
        {
            Debug.Log("Pressed button: " + buttonIndex);
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
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void TutorialButton()
    {
        // SceneManager.LoadScene("Tutorial");
    }

    public void AchievementsButton()
    {
        
    }

    public void CreditsButton()
    {
        // Credits
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
