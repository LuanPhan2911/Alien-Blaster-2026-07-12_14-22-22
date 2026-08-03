
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{


    private Animator animator;

    const string HORIZONTAL = "Horizontal";
    const string IS_JUMPING = "IsJumping";

    const string IS_CLIMBING = "IsClimbing";




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
}
