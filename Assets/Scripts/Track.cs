using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Track : PooledlMonoBehaviour, ITakeHit
{
    [SerializeField] List<Transform> _trackLane;
    [SerializeField] List<Transform> _obstaclePoint;
    [SerializeField] Obstacle[] _obstacles;
    List<Obstacle> _obstacleList;

    public List <Transform> TrackLanes => _trackLane;

    public void TakeDamage()
    {
        
    }
    
    void Start()
    {
        _obstacleList = new List<Obstacle>();
        _trackLane = GetComponentsInChildren<Transform>().ToList();
        _trackLane.RemoveAt(0);
        for (int i = 0; i < _obstaclePoint.Count; i++)
        {
            var newObstacle =  _obstacles[Random.Range(0,_obstacles.Length)].Get<Obstacle>();
            _obstacleList.Add(newObstacle);
            newObstacle.transform.position = _obstaclePoint[i].position;
        }
    }

    public void Return()
    {
        foreach (var obstacle in _obstacleList)
        {
            obstacle.ReturnToPool();
        }
        _obstacleList.Clear();
        ReturnToPool(3f);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<RunnerMovement>() != null)
            TrackManager.Instance.PlayerTrigger();
    }
}
