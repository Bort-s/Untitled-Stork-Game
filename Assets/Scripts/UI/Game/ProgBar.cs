using System.Diagnostics;
using System.Collections;
using UnityEngine;
using Debug = UnityEngine.Debug;
public class ProgBar : MonoBehaviour
{
    private float velocidad = 0.008f;
    private float actualProgress = 0.01f;
    private bool increasing = false;

    public GameObject progressBar;

    void Update()
    {
        if (actualProgress < GameData.gameProgress && !increasing)
        {
            increasing = true;
            actualProgress = actualProgress + 1f;
            StartCoroutine(ProgressBarBehavior());
        }
    }

    private IEnumerator ProgressBarBehavior()
    {
        Vector3 scale = progressBar.transform.localScale;
        scale.x = actualProgress * 0.01f;
        progressBar.transform.localScale = scale;
        yield return new WaitForSeconds(velocidad);
        increasing = false;
    }
}
