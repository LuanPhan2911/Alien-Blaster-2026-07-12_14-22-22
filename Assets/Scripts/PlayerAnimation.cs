
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{


    private Animator animator;

    const string IS_WALKING = "IsWalking";
    const string IS_JUMPING = "IsJumping";


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetWalking(bool isWalking)
    {
        animator.SetBool(IS_WALKING, isWalking);
    }
    public void SetJumPing(bool isJumping)
    {
        animator.SetBool(IS_JUMPING, isJumping);
    }

    public void SetIdle()
    {
        animator.SetBool(IS_WALKING, false);
        animator.SetBool(IS_JUMPING, false);
    }
}
