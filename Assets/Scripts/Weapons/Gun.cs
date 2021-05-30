using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Bullet _bullet;
    [SerializeField] Transform _spawnPoint;

    public void Fire()
    {
        Instantiate(_bullet.gameObject, _spawnPoint.position, _spawnPoint.rotation);

    }
}
