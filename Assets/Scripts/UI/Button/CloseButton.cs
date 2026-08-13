using UnityEngine;

public class CloseButton : MonoBehaviour
{
    [SerializeField] private GameObject cloudWall;
    [SerializeField] private GameObject creditsWall;
    [SerializeField] private GameObject recordsWall;
    private float wallSpeed = 11f;
    private Vector3? wallTarget = null;
    private Vector3? creditsTarget = null;
    private Vector3? recordsTarget = null;


    void Update()
    {
        if (wallTarget.HasValue)
        {
            cloudWall.transform.position = Vector3.MoveTowards(cloudWall.transform.position, wallTarget.Value, wallSpeed * Time.deltaTime);

            if (Vector3.Distance(cloudWall.transform.position, wallTarget.Value) < 0.001f)
            {
                wallTarget = null;
            }
        }

        if (recordsTarget.HasValue)
        {
            recordsWall.transform.position = Vector3.MoveTowards(recordsWall.transform.position, recordsTarget.Value, wallSpeed * Time.deltaTime);

            if (Vector3.Distance(recordsWall.transform.position, recordsTarget.Value) < 0.001f)
            {
                recordsTarget = null;
            }
        }

        if (creditsTarget.HasValue)
        {
            creditsWall.transform.position = Vector3.MoveTowards(creditsWall.transform.position, creditsTarget.Value, wallSpeed * Time.deltaTime);

            if (Vector3.Distance(creditsWall.transform.position, creditsTarget.Value) < 0.001f)
            {
                creditsTarget = null;
            }
        }
    }

    private void OnMouseUpAsButton()
    {
        if (!wallTarget.HasValue)
        {
            Debug.Log("Pressed button: Close");
            MenuData.isMenuActive = true;
            wallTarget = new Vector3(0f, -7f, 0f);
            recordsTarget = new Vector3(0f, -7.5f, 0f);
            creditsTarget = new Vector3(0f, -7.5f, 0f);
        }
    }
}
