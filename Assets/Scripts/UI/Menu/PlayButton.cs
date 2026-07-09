using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.SceneManagement;
public class PlayButton : MonoBehaviour
{
    public GameObject gameWall;
    private float wallSpeed = 11f;
    private Vector3? wallTarget;

    void awake()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        if (wallTarget.HasValue && gameWall != null)
        {
            gameWall.transform.position = Vector3.MoveTowards(gameWall.transform.position, wallTarget.Value, wallSpeed * Time.deltaTime);

            if (Vector3.Distance(gameWall.transform.position, wallTarget.Value) < 0.001f)
                SceneManager.LoadScene("Game");
        }
    }

    private void OnMouseUpAsButton()
    {
        if (MenuData.isMenuActive)
        {
            Debug.Log("Pressed button: Play");
            wallTarget = new Vector3(0f, 0f, 0f);
        }
    }
}
