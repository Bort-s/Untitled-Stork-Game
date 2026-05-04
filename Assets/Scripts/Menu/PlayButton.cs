using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("Game");
        Debug.Log("Play button clicked, loading Game scene.");
    }
}
