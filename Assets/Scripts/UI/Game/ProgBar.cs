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
        if (actualProgress < GameData.gameProgress && !increasing && !GameData.gameCompleted)
        {
            increasing = true;
            actualProgress = actualProgress + 1f;
            StartCoroutine(ProgressBarBehavior());
        }
    }

    IEnumerator ProgressBarBehavior()
    {
        Vector3 scale = progressBar.transform.localScale;
        scale.x = actualProgress * 0.01f;
        progressBar.transform.localScale = scale;
        /*
        Vector3 pos = progressBar.transform.localPosition;
        pos.x = -1.06256f;
        progressBar.transform.localPosition = pos;*/
        yield return new WaitForSeconds(velocidad);
        increasing = false;
    }
}
