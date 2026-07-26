using UnityEngine;

public class ExitButton : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        if (MenuData.isMenuActive)
        {
            Debug.Log("Pressed button: Exit");
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}
