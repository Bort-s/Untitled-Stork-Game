using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private float elapsedTime = 0.01f;
    private bool isCounting = false;

    private void Update()
    {
        if (isCounting)
            elapsedTime += Time.deltaTime;
    }

    public void StartTimer() => isCounting = true;
    public void StopTimer()  => isCounting = false;
    public void ResetTimer() => elapsedTime = 0f;
    public float GetElapsedTime() => elapsedTime;
}