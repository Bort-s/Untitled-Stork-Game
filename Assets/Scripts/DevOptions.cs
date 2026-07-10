using UnityEngine;

public class DevOptions : MonoBehaviour
{
    public bool noDamage = false;
    void Update()
    {
        if (noDamage)
            GameData.playerCanTakeDamage = false;
    }
}
