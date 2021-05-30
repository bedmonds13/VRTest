using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] float _speed =2;
    private Rigidbody rb;
    private void Awake()  => rb = GetComponent<Rigidbody>();

    void Start()
    {
        var force = transform.rotation * Vector3.forward * _speed * Time.deltaTime;
        rb.AddForce(force, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        var player = collision.collider.GetComponent<ITakeHit>();
        if (player != null)
        {
            player.TakeDamage();
        }
    }
}
