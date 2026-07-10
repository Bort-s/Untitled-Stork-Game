using System.Diagnostics;
using System.Collections;
using UnityEngine;
using Debug = UnityEngine.Debug;
public class ProgBar : MonoBehaviour
{
    private float velocidad = 0.008f;
    private float progressPercentage;
    private bool increasing = false;

    public GameObject progressBar;

    void Update()
    {
        progressPercentage = GameData.gameProgress / GameDifficulty.maxGameProgress;

        if (GameData.gameProgress != 0 && !increasing)
        {
            increasing = true;
            
            StartCoroutine(ProgressBarBehavior());
        }
    }

    private IEnumerator ProgressBarBehavior()
    {
        Vector3 scale = progressBar.transform.localScale;
        scale.x = progressPercentage;
        progressBar.transform.localScale = scale;
        yield return new WaitForSeconds(velocidad);
        increasing = false;
    }
}
