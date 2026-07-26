using UnityEngine;

public class CreditsButton : MonoBehaviour
{
    public GameObject cloudWall;
    private float wallSpeed = 11f;
    private Vector3? wallTarget = null;
    
    void Update()
    {

        if (wallTarget.HasValue && cloudWall != null)
        {
            cloudWall.transform.position = Vector3.MoveTowards(cloudWall.transform.position, wallTarget.Value, wallSpeed * Time.deltaTime);

            if (Vector3.Distance(cloudWall.transform.position, wallTarget.Value) < 0.001f)
                wallTarget = null;
        }
    }

    private void OnMouseUpAsButton()
    {
        if (MenuData.isMenuActive)
        {
            Debug.Log("Pressed button: Credits");
            MenuData.isMenuActive = false;
            wallTarget = new Vector3(0f, 0.5f, 0f);
        }
    }
}
