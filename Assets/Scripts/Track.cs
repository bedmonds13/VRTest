using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Track : PooledlMonoBehaviour
{
    [SerializeField] List <Transform> _trackLane;
    public List <Transform> TrackLanes => _trackLane;
    private void Awake() 
    {
        _trackLane = GetComponentsInChildren<Transform>().ToList();
        _trackLane.RemoveAt(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<RunnerMovement>() != null)
            TrackManager.Instance.PlayerTrigger();
    }
}
