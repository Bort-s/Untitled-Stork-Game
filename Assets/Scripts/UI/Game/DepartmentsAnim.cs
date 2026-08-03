using UnityEngine;
using System.Collections;

public class DepartmentsAnim : MonoBehaviour
{
    private float depaSpeed = 5f;
    private Vector3? depaTarget = null;
    private bool onCoroutine = false;

    void Update()
    {
        if (GameData.gameCompleted && !onCoroutine)
        {
            onCoroutine = true;
            StartCoroutine(DepaAnim());
        }

        if (depaTarget.HasValue)
        {
            transform.position = Vector3.MoveTowards(transform.position, depaTarget.Value, depaSpeed * Time.deltaTime);
        }
    }
    private IEnumerator DepaAnim()
    {
        yield return new WaitForSeconds(6f);
        depaTarget = new Vector3(4.5f, -3f, 0f);
    }
}
