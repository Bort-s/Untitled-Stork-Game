using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverWall : MonoBehaviour
{
    private float wallSpeed = 11f;
    private Vector3? wallTarget = null;
    void Update()
    {
        if (GameData.launchGameOver)
        {
            wallTarget = new Vector3(0f, 0f, 0f);
            transform.position = Vector3.MoveTowards(transform.position, wallTarget.Value, wallSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, wallTarget.Value) < 0.001f)
                SceneManager.LoadScene("GameOver");
        }
    }
}
