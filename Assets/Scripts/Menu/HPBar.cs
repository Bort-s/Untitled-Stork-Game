using System.Diagnostics;
using System.Collections;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class HPBar : MonoBehaviour
{
    private Animator animator;

    private float velocidad = 0.008f;
    private float actualHealt = 100f;
    private bool decreasing = false;

    public GameObject HPBarObject;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameData.isDead)
        {
            OnDead();
        }
        
        if (actualHealt != GameData.playerHealth && !decreasing)
        {
            decreasing = true;
            actualHealt = actualHealt - 1f;
            StartCoroutine(HPBarBehavior());
        }
    }

    IEnumerator HPBarBehavior()
    {
        Vector3 scale = HPBarObject.transform.localScale;
        scale.x = actualHealt * 0.01f;
        HPBarObject.transform.localScale = scale;
        Vector3 pos = HPBarObject.transform.localPosition;
        pos.x = -1.41703f;
        HPBarObject.transform.localPosition = pos;
        yield return new WaitForSeconds(velocidad);
        decreasing = false;
    }

    void OnDead()
    {
        Destroy(HPBarObject);
    }
}
