using UnityEngine;

public class TutorialButton : MonoBehaviour
{
    void awake()
    {
        Application.targetFrameRate = 60;
    }
    private void OnMouseUpAsButton()
    {
        if (MenuData.isMenuActive)
        {
            Debug.Log("Pressed button: Tutorial");
            MenuData.isMenuActive = false;
            // SceneManager.LoadScene("Tutorial");
        }
    }
}