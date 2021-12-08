using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimationPlayer : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayIdleAnimation()
    {
        _animator.Play(EnemyAnimatorController.States.Idle);
    }

    public void PlayDeathAnimation()
    {
        _animator.Play(EnemyAnimatorController.States.Dying);
    }
}
