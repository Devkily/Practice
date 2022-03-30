using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerFB : ObjectPoolFB
{
    [SerializeField] private GameObject[] _pipePrefabs;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _minSpawnSpeed;
    [SerializeField] private float _maxSpawnSpeed;
    private float _spawnSpeed;

    private float _elapsedTime = 0;
    private void Start()
    {
        Initialize(_pipePrefabs);
    }
    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _spawnSpeed)
        {
            if (TryGetObject(out GameObject pipe))
            {
                _elapsedTime = 0;
                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
                _spawnSpeed = Random.Range(_minSpawnSpeed, _maxSpawnSpeed);
                SetPipe(pipe, _spawnPoints[spawnPointNumber].position);
            }

        }
    }
    private void SetPipe(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}

