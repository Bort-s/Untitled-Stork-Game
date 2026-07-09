using UnityEngine;
using System.Collections;
using Debug = UnityEngine.Debug;
using UnityEngine.SceneManagement;


public class GameOverWall : MonoBehaviour
{
    private float wallSpeed = 11f;
    private Vector3? wallTarget = null;
    private bool wallActivated = false;

    private float timeBeforeWall = 2f;

    void Update()
    {
        if (!wallActivated && GameData.isDead)
        {
            wallActivated = true;
            StartCoroutine(LaunchWall());
        }
    }


    private IEnumerator LaunchWall()
    {
        yield return new WaitForSeconds(timeBeforeWall);
        wallTarget = Vector3.zero;
        while (Vector3.Distance(transform.position, wallTarget.Value) > 0.001f)
        {
            transform.position = Vector3.MoveTowards(transform.position, wallTarget.Value, wallSpeed * Time.deltaTime);
            yield return null;
        }
        SceneManager.LoadScene("GameOver");
    }
}
