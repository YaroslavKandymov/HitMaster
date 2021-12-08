using System;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private List<EnemyHealth> _enemies;

    private int _dieCounter;
    private List<ColliderController> _colliderControllers = new List<ColliderController>();

    public event Action Cleared;

    private void Awake()
    {
        foreach (var enemy in _enemies)
            _colliderControllers.Add(enemy.GetComponent<ColliderController>());
    }

    private void OnEnable()
    {
        foreach (var enemy in _enemies)
            enemy.Died += OnDied;
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
            enemy.Died -= OnDied;
    }

    public void ActivateColliders()
    {
        foreach (var colliderController in _colliderControllers)
            colliderController.Activate();
    }

    private void OnDied()
    {
        _dieCounter++;

        if(_dieCounter >= _enemies.Count)
            Cleared?.Invoke();
    }
}
