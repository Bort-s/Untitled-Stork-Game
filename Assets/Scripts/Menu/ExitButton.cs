using UnityEngine;

public class ExitButton : MonoBehaviour
{
    void OnMouseDown()
    {
        Application.Quit();
 
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
