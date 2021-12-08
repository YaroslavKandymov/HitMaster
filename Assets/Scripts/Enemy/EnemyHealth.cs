using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _secondsBeforeDisappear;
    [SerializeField] private EnemyAnimationPlayer _animationPlayer;

    private CapsuleCollider _collider;

    public event Action Died;

    private void Start()
    {
        _collider = GetComponent<CapsuleCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Bullet bullet))
        {
            Die();
            bullet.gameObject.SetActive(false);
        }
    }

    public void Die()
    {
        _collider.enabled = false;
        _animationPlayer.PlayDeathAnimation();

        StartCoroutine(DieCoroutine());
    }

    private IEnumerator DieCoroutine()
    {
        yield return  new WaitForSeconds(_secondsBeforeDisappear);

        gameObject.SetActive(false);
        Died?.Invoke();
    }
}
