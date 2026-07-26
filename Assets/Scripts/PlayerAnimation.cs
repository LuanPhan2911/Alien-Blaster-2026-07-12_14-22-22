
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{


    private Animator animator;

    const string HORIZONTAL = "Horizontal";
    const string IS_JUMPING = "IsJumping";


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    public void SetJumPing(bool isJumping)
    {
        animator.SetBool(IS_JUMPING, isJumping);
    }

    public void SetHorizontal(float horizontal)
    {
        animator.SetFloat(HORIZONTAL, Mathf.Abs(horizontal));
    }
}
