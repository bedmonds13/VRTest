using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Track : MonoBehaviour
{
    [SerializeField] List <Transform> _trackLane;
    public List <Transform> TrackLanes => _trackLane;
    private void Awake() 
    {
        _trackLane = GetComponentsInChildren<Transform>().ToList();
        _trackLane.RemoveAt(0);
    }
}
