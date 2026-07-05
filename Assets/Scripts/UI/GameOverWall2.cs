using UnityEngine;

public class GameOverWall2 : MonoBehaviour
{
    private float wallSpeed = 11f;
    private Vector3? wallTarget = null;

    void Start()
    {
        wallTarget = new Vector3(14f, 0f, 0f);
    }

    void Update()
    {
        if (wallTarget.HasValue)
        {
            transform.position = Vector3.MoveTowards(transform.position, wallTarget.Value, wallSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, wallTarget.Value) < 0.001f)
                wallTarget = null;
        }
    }
}
