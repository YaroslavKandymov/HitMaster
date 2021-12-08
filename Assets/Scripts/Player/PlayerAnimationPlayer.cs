using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationPlayer : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayIdleAnimation()
    {
        _animator.SetTrigger(PlayerAnimatorController.Params.Idle);
    }

    public void PlayRunAnimation()
    {
        _animator.Play(PlayerAnimatorController.States.Run);
    }
}
