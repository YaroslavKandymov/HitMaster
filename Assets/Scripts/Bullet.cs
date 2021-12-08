using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletData _bulletData;

    private Transform _transform;
    private Vector3 _direction;
    private Rigidbody _rigidbody;
    private WaitForSeconds _seconds;

    public Transform Transform => _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();
        _seconds = new WaitForSeconds(_bulletData.ExistTime);
    }

    public void Init(Vector3 direction)
    {
        _direction = direction;
    }

    public void Fire()
    {
        _rigidbody.velocity = _direction * _bulletData.Speed * Time.deltaTime;

        StartCoroutine(AutoShutdown());
    }

    private IEnumerator AutoShutdown()
    {
        yield return _seconds;

        if(enabled == true)
            gameObject.SetActive(false);
    }
}