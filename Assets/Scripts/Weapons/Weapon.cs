using UnityEngine;

public abstract class Weapon : ObjectPool<Bullet>
{
    [SerializeField] private BulletData _bulletData;
    [SerializeField] private Transform _shootPoint;

    protected Transform ShootPoint => _shootPoint;

    private void Start()
    {
        Initialize(_bulletData.Prefab);
    }

    public abstract void Shoot(Vector3 targetPoint);
}
