using UnityEngine;

[CreateAssetMenu(fileName = "new BulletData", menuName = "BulletData", order = 51)]
public class BulletData : ScriptableObject
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private float _speed;
    [SerializeField] private float _existTime;

    public Bullet Prefab => _prefab;
    public float Speed => _speed;
    public float ExistTime => _existTime;
}
