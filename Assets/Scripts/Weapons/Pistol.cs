using UnityEngine;

public class Pistol : Weapon
{
    public override void Shoot(Vector3 targetPoint)
    {
        if (TryGetObject(out Bullet bullet))
        {
            bullet.Transform.position = ShootPoint.position;

            var direction = (targetPoint - ShootPoint.position).normalized;

            bullet.Init(direction);
            bullet.gameObject.SetActive(true);
            bullet.Fire();
        }
    }
}
