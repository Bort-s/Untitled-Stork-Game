using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.SceneManagement;
public class MenuButton : MonoBehaviour
{
    [SerializeField] private GameObject menuWall;
    private float wallSpeed = 11f;
    private Vector3? wallTarget;

    void Update()
    {
        if (wallTarget.HasValue && menuWall != null)
        {
            menuWall.transform.position = Vector3.MoveTowards(menuWall.transform.position, wallTarget.Value, wallSpeed * Time.deltaTime);

            if (Vector3.Distance(menuWall.transform.position, wallTarget.Value) < 0.001f)
            {
                MenuData.isMenuActive = true;
                SceneManager.LoadScene("Menu");
            }
        }
    }

    private void OnMouseUpAsButton()
    {
        if (MenuData.isMenuActive)
        {
            Debug.Log("Pressed button: Menu");
            MenuData.isMenuActive = false;
            wallTarget = new Vector3(0f, 0f, 0f);
        }
    }
}
