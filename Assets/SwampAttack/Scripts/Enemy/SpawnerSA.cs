using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnerSA : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private PlayerSA _player;

    private Wave _curentWave;
    private int _currentWaveNumber;
    private float _timeAfterLastSpawn;
    private int _spawned;
    public event UnityAction AllEnemySpawned;
    public event UnityAction<int,int> EnemyCountChenged;
    private void Start()
    {
        SetWave(_currentWaveNumber);
    }
    private void Update()
    {
        if (_curentWave == null)
        {
            return;
        }
        _timeAfterLastSpawn += Time.deltaTime;
        if (_timeAfterLastSpawn >= _curentWave.Delay)
        {
            InstantiateEnemy();
            _spawned++;
            _timeAfterLastSpawn = 0;
            EnemyCountChenged?.Invoke(_spawned, _curentWave.Count);
        }
        if (_curentWave.Count <= _spawned)
        {
            if (_waves.Count > _currentWaveNumber + 1)
            {
                AllEnemySpawned?.Invoke();
            }
            _curentWave = null;
        }
    }
    private void InstantiateEnemy()
    {
        EnemySA enemy = Instantiate(_curentWave.Template, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint).GetComponent<EnemySA>();
        enemy.Init(_player);
        enemy.EnemyDied += OnEnemyDied;
    }
    private void SetWave(int index)
    {
        _curentWave = _waves[index];
        EnemyCountChenged?.Invoke(0, 1);
    }
    public void NextWave()
    {
        SetWave(++_currentWaveNumber);
        _spawned = 0;
    }
    private void OnEnemyDied(EnemySA enemy)
    {
        enemy.EnemyDied -= OnEnemyDied;
        _player.AddMoney(enemy.Reward);
    }
}
[System.Serializable]
public class Wave
{
    public GameObject Template;
    public float Delay;
    public int Count;
}
