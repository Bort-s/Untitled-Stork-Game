using UnityEngine;

public class playerHealth : MonoBehaviour
{
    // Health
    public float timeToDecrease = 5f;
    private float timer;

    void Start()
    {
        timeToDecrease = GameData.maxGameProgress / 50f;
    }

    void Update()
    {
        if (GameData.playerCanTakeDamage)
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
}
