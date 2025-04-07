using UnityEngine;

public static class PlayerAnimatorData
{
    public static class Params
    {
        public static readonly int SideSpeed = Animator.StringToHash(nameof(SideSpeed));
        public static readonly int ForwardSpeed = Animator.StringToHash(nameof(ForwardSpeed));
    }
}
