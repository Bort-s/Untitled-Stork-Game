using UnityEngine;

public class playerHealth : MonoBehaviour
{
    // Health
    public float timeToDecrease = 3f;
    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= timeToDecrease)
        {
            timer = 0f;
            GameData.playerHealth -= 1f;
            Debug.Log("New Player Health: " + GameData.playerHealth);
        }
    }
}
