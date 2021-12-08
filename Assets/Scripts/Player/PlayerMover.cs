using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private List<Waypoint> _waypoints;
    [SerializeField] private PlayerAnimationPlayer _animationPlayer;
    [SerializeField] private float _pointReachDistance;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private EnemyWaves _enemyWaves;

    private readonly Queue<Waypoint> _waypointsQueue = new Queue<Waypoint>();
    private Coroutine _coroutine;
    private bool _canMove;

    public bool CanMove => _canMove;

    public event Action MoveStarted;
    public event Action MoveEnded;
    public event Action PathEnded;

    private void OnEnable()
    {
        _enemyWaves.WaveCleared += OnWaveCleared;
    }

    private void OnDisable()
    {
        _enemyWaves.WaveCleared -= OnWaveCleared;
    }

    private void Start()
    {
        foreach (var waypoint in _waypoints)
            _waypointsQueue.Enqueue(waypoint);
    }

    private void OnWaveCleared()
    {
        _canMove = true;
    }

    public void MoveToNextPoint()
    {
        if(_coroutine != null)
            return;

        Waypoint waypoint = _waypointsQueue.Dequeue();

        MoveStarted?.Invoke();

        _animationPlayer.PlayRunAnimation();
        _agent.SetDestination(waypoint.transform.position);
        transform.LookAt(waypoint.transform.position);

        _coroutine = StartCoroutine(MoveToCoroutine(waypoint));
    }

    private IEnumerator MoveToCoroutine(Waypoint waypoint)
    {
        while (true)
        {
            if (Vector3.Distance(transform.position, waypoint.transform.position) <= _pointReachDistance)
            {
                if(_waypointsQueue.Count <= 0)
                    PathEnded?.Invoke();

                _animationPlayer.PlayIdleAnimation();
                _canMove = false;
                MoveEnded?.Invoke();

                _coroutine = null;
                yield break;
            }

            yield return null;
        }
    }
}
