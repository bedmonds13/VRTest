using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Track : PooledlMonoBehaviour
{
    [SerializeField] List<Transform> _trackLane;
    [SerializeField] List<Transform> _trackObjectPosition;
    [SerializeField] TrackObject[] _trackObjects;
    List<TrackObject> _trackObjectList;

    public List <Transform> TrackLanes => _trackLane;

    void Start()
    {
        _trackObjectList = new List<TrackObject>();
        _trackLane = GetComponentsInChildren<Transform>().ToList();
        _trackLane.RemoveAt(0);
        SetObjects();
    }

    void OnEnable()
    {
        //SetObjects();
        
    }
    private void SetObjects()
    {
        for (int i = 0; i < _trackObjectPosition.Count; i++)
        {
            var newObstacle = _trackObjects[Random.Range(0, _trackObjects.Length)].Get<TrackObject>();
            _trackObjectList.Add(newObstacle);
            newObstacle.transform.position = _trackObjectPosition[i].position;
        }
    }

    public void Return()
    {
        foreach (var obstacle in _trackObjectList)
        {
            obstacle.ReturnToPool();
        }
        _trackObjectList.Clear();
        ReturnToPool(3f);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<RunnerMovement>() != null)
            TrackManager.Instance.PlayerTrigger();
    }
}
