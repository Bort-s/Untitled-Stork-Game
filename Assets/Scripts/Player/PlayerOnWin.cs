using UnityEngine;
using System.Collections;

public class PlayerOnWin : MonoBehaviour
{
    private float acceleration = 0.03f;

    private Vector3[] playerTarget = 
    {
        new Vector3(-2f, 2f, 0f),
        new Vector3(-0.55f, 2f, 0f),
        new Vector3(7f, 2f, 0f),
    };

    private int index = 0;


    private bool hasStarted = false;

    void Update()
    {
        if (GameData.gameCompleted)
        {
            if (index == 0)
            {
                if (GameData.speed > 2.1f)
                {
                    GameData.speed -= acceleration;
                }
                else if (GameData.speed < 1.9f)
                {
                    GameData.speed += acceleration;
                }
            }

            if (!hasStarted)
            {
                StartCoroutine(WinAnim());
                hasStarted = true;
            }

            transform.position = Vector3.MoveTowards(transform.position, playerTarget[index], GameData.speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, playerTarget[2]) < 0.001f)
            {
                GameData.launchWall = true;
            }
        }
    }

    private IEnumerator WinAnim()
    {
        index = 0;
        yield return new WaitForSeconds(8f);
        index = 1;
        yield return new WaitForSeconds(4f);
        GameData.speed = 4f;
        index = 2;
    }
}
