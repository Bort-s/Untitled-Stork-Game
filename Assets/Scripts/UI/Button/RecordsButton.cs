using UnityEngine;

public class RecordsButton : MonoBehaviour
{
    [SerializeField] private GameObject cloudWall;
    [SerializeField] private GameObject recordsWall;
    private float wallSpeed = 11f;
    private float recordsSpeed = 11f;
    private Vector3? wallTarget = null;
    private Vector3? recordsTarget = null;

    void Update()
    {
        if (wallTarget.HasValue)
        {
            cloudWall.transform.position = Vector3.MoveTowards(cloudWall.transform.position, wallTarget.Value, wallSpeed * Time.deltaTime);

            if (Vector3.Distance(cloudWall.transform.position, wallTarget.Value) < 0.001f)
                wallTarget = null;
        }

        if (recordsTarget.HasValue)
        {
            recordsWall.transform.position = Vector3.MoveTowards(recordsWall.transform.position, recordsTarget.Value, recordsSpeed * Time.deltaTime);
            if (Vector3.Distance(recordsWall.transform.position, recordsTarget.Value) < 0.001f)
                recordsTarget = null;
        }
    }

    private void OnMouseUpAsButton()
    {
        if (MenuData.isMenuActive)
        {
            Debug.Log("Pressed button: Records");
            MenuData.isMenuActive = false;
            wallTarget = new Vector3(0f, 0.5f, 0f);
            recordsTarget = new Vector3(0f, 0f, 0f);
        }
    }
}
