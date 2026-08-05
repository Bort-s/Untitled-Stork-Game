using UnityEngine;

public class DevOptions : MonoBehaviour
{
    [SerializeField] private bool noDamage = false;
    [SerializeField] private bool instantDeath = false;
    [SerializeField] private bool instantWin = false;

    void Start()
    {
        if (instantDeath)
            GameData.playerHealth = 98f;

        if (instantWin)
            GameData.gameProgress = GameDifficulty.maxGameProgress * 0.98f;
    }
    void Update()
    {
        if (noDamage)
            GameData.playerCanTakeDamage = false;


    }
}
