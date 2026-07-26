using UnityEngine;

public class DevOptions : MonoBehaviour
{
    public bool noDamage = false;
    public bool instantDeath = false;
    public bool instantWin = false;

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
