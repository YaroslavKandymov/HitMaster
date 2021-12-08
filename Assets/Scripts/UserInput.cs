using UnityEngine;

public class UserInput : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerShooter _playerShooter;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_playerMover.CanMove)
            {
                _playerMover.MoveToNextPoint();
            }
            else if (_playerShooter.CanShoot)
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    _playerShooter.Shoot(hit.point);
                }
            }
        }
    }
}
