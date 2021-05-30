using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour, ITakeHit  
{
    [SerializeField] float _speed = 3;
    [SerializeField] GameObject _particleEffect;
    Rigidbody rb => GetComponent<Rigidbody>();
    void Start()
    {
        var force = transform.up * _speed * Time.deltaTime;
        rb.AddForce(force);
    }
    public void TakeDamage()
    {
        Instantiate(_particleEffect, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

}
