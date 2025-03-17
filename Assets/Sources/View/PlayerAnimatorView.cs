using UnityEngine;

public class PlayerAnimatorView : MonoBehaviour
{
    [SerializeField] private Animator _bodyAnimator;
    [SerializeField] private Animator _gunAnimator;

    public void UpdateView(Vector2 direction)
    {
        SetParams(_gunAnimator, direction);
        SetParams(_bodyAnimator, direction);
    }

    private void SetParams(Animator animator, Vector2 direction)
    {
        animator.SetFloat(PlayerAnimatorData.Params.ForwardSpeed, direction.y);
        animator.SetFloat(PlayerAnimatorData.Params.SideSpeed, direction.x);
    }
}
