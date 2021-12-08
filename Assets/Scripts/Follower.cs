using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Vector3 _offset;
    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _offset = _transform.position - _target.transform.position;
    }

    private void LateUpdate()
    {
        _transform.position = _target.transform.position + _offset;
    }
}
