using UnityEngine;

public class HPBarAnim : MonoBehaviour
{
    private Animator animator;

    private bool hasBeenTriggered = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (animator != null && GameData.isDead && !hasBeenTriggered)
        {
            animator.SetTrigger("HP Bar");
            hasBeenTriggered = true;
        }
    }
}
