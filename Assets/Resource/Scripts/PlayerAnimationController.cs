using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private string currentAnimationState;

    // The state names for each animation
    private const string IdleWState = "IdleW";
    private const string IdleBState = "IdleB";
    private const string WalkingWState = "WalkingW";
    private const string WalkingBState = "WalkingB";
    private const string JumpingWState = "JumpingW";
    private const string JumpingBState = "JumpingB";
    private const string SwitchingState = "Switching";

    private void Start()
    {
        animator = GetComponent<Animator>();
        currentAnimationState = IdleWState;
    }

    private void Update()
{
    // Check if the player is moving left or right
    float horizontalInput = Input.GetAxisRaw("Horizontal");

    if (horizontalInput != 0f)
    {
        // Update animation state to walking
        if (horizontalInput > 0f)
        {
            currentAnimationState = WalkingWState;
        }
        else
        {
            currentAnimationState = WalkingBState;
        }
    }
    else
    {
        // Update animation state to idle
        if (currentAnimationState == WalkingWState || currentAnimationState == JumpingWState)
        {
            currentAnimationState = IdleWState;
        }
        else if (currentAnimationState == WalkingBState || currentAnimationState == JumpingBState)
        {
            currentAnimationState = IdleBState;
        }
    }

    // Check if the player is jumping
    bool isJumping = Input.GetButtonDown("Jump");

    if (isJumping)
    {
        // Update animation state to jumping
        if (currentAnimationState == IdleWState || currentAnimationState == WalkingWState)
        {
            currentAnimationState = JumpingWState;
        }
        else if (currentAnimationState == IdleBState || currentAnimationState == WalkingBState)
        {
            currentAnimationState = JumpingBState;
        }
    }

    // Check if the animation state needs to be switched
    int currentAnimationStateHash = Animator.StringToHash(currentAnimationState);
    if (currentAnimationStateHash != animator.GetCurrentAnimatorStateInfo(0).shortNameHash)
    {
        animator.Play(SwitchingState);
        animator.Play(currentAnimationStateHash);
    }
}

}
