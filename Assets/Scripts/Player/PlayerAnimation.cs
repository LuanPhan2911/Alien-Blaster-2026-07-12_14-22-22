
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{


    private Animator animator;

    const string HORIZONTAL = "Horizontal";
    const string IS_JUMPING = "IsJumping";

    const string IS_CLIMBING = "IsClimbing";

    const string IS_FALLING = "IsFalling";

    const string IS_SWIMMING = "IsSwimming";




    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    public void SetJumping(bool isJumping)
    {
        animator.SetBool(IS_JUMPING, isJumping);
    }

    public void SetHorizontal(float horizontal)
    {
        animator.SetFloat(HORIZONTAL, Mathf.Abs(horizontal));
    }
    public void SetClimbing(bool isClimbing)
    {
        animator.SetBool(IS_CLIMBING, isClimbing);
    }

    public void SetFalling(bool isFalling)
    {
        animator.SetBool(IS_FALLING, isFalling);
    }
    public void SetSwimming(bool isSwimming)
    {
        animator.SetBool(IS_SWIMMING, isSwimming);
    }

    public void PauseCurrentAnimation()
    {
        animator.speed = 0f;
    }
    public void StartCurrentAnimation()
    {
        animator.speed = 1f;
    }
}
