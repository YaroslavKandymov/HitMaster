using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;

    private readonly Queue<Wave> _wavesQueue = new Queue<Wave>();
    private Wave _currentWave;

    public event Action WaveCleared;

    private void Awake()
    {
        foreach (var wave in _waves)
            _wavesQueue.Enqueue(wave);
    }

    private void OnEnable()
    {
        foreach (var wave in _wavesQueue)
            wave.Cleared += OnCleared;
    }

    private void OnDisable()
    {
        foreach (var wave in _wavesQueue)
            wave.Cleared -= OnCleared;
    }

    private void Start()
    {
        GetNextWave();
    }

    private void OnCleared()
    {
        WaveCleared?.Invoke();

        if (_wavesQueue.Count <= 0)
            return;

        GetNextWave();
    }

    private void GetNextWave()
    {
        _currentWave = _wavesQueue.Dequeue();
        _currentWave.ActivateColliders();
    }
}
