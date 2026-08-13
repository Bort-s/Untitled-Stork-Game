using UnityEngine;
using System.Collections;

public class PlayerOnWin : MonoBehaviour
{
    private Animator animator;
    private int index = 0;
    private bool hasStarted = false;
    private float acceleration = 1.8f;

    private Vector3[] playerTarget = 
    {
        new Vector3(-2f, 2f, 0f),
        new Vector3(-0.55f, 2f, 0f),
        new Vector3(7f, 2f, 0f),
    };

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameData.gameCompleted)
        {
            if (index == 0)
            {
                if (GameData.speed > 2.1f)
                {
                    GameData.speed -= acceleration * Time.deltaTime;
                }
                else if (GameData.speed < 1.9f)
                {
                    GameData.speed += acceleration * Time.deltaTime;
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
        yield return new WaitForSeconds(2f);

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float actualTime = stateInfo.normalizedTime % 1f;
        animator.Play("StorkVariation", 0, actualTime);
        
        yield return new WaitForSeconds(2f);
        GameData.speed = 4f;
        index = 2;
    }
}
