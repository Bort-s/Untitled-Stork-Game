using UnityEngine;

public class TutorialButton : MonoBehaviour
{
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