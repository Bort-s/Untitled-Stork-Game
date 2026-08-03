using UnityEngine;
using UnityEngine.SceneManagement;

public class WinWall : MonoBehaviour
{
    private float wallSpeed = 11f;
    private Vector3? wallTarget = null;

    void Update()
    {
        if (GameData.launchWall)
        {
            wallTarget = new Vector3(-0.5f, 0f, 0f);
        }

        if (wallTarget.HasValue)
        {
            transform.position = Vector3.MoveTowards(transform.position, wallTarget.Value, wallSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, wallTarget.Value) < 0.001f)
                SceneManager.LoadScene("WinScreen");
        }


    }
}
