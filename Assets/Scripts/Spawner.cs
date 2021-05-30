using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject _spawnedObjected;
    [SerializeField] float _spawnRate = 3;
    float _timeReset;

    private void Awake()
    {
        _timeReset = _spawnRate;
    }
    private void Update()
    {
        if (_timeReset > 0)
            _timeReset -= Time.deltaTime;
        else
        {

            _timeReset = _spawnRate;
            Instantiate(_spawnedObjected, transform.position, transform.rotation);
        }
    }
}
