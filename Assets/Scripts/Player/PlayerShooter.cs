using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private PlayerMover _playerMover;

    private bool _canShoot;
    private Weapon _currentWeapon;

    public bool CanShoot => _canShoot;

    private void OnEnable()
    {
        _playerMover.MoveStarted += OnMoveStarted;
        _playerMover.MoveEnded += OnMoveEnded;
    }

    private void OnDisable()
    {
        _playerMover.MoveStarted -= OnMoveStarted;
        _playerMover.MoveEnded -= OnMoveEnded;
    }

    private void Start()
    {
        _canShoot = true;
        _currentWeapon = _weapons[0];
    }

    public void Shoot(Vector3 point)
    {
        _currentWeapon.Shoot(point);
    }

    private void OnMoveStarted()
    {
        _canShoot = false;
    }

    private void OnMoveEnded()
    {
        _canShoot = true;
    }
}
