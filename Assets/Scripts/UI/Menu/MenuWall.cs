using System.Collections;
using UnityEngine;

public class MenuWall : MonoBehaviour
{
    private float wallSpeed = 11f;
    private Vector3? wallTarget = null;

    private float loadDelay = 0.5f;

    void Awake()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
    }

    void Start()
    {
        StartCoroutine(StartMenu());
        
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

    private IEnumerator StartMenu()
    {
        if (MenuData.isFirstLoad)
            yield return new WaitForSeconds(loadDelay);
        else
            yield return null;
            
        wallTarget = new Vector3(14f, 0f, 0f);
    }
}
