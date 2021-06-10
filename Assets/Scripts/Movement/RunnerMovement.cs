using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerMovement : MonoBehaviour
{
    [SerializeField] float _verticalSpeed = 2f;
    [SerializeField] float _horizontalSpeed = 2f;
    [SerializeField] Track  _currentTrack;
    [SerializeField] float _horizontalMovementDelay = 3f;
    float _timer;
    int _currentLaneIndex;

    public bool SwitchingLanes { get; private set; }
   
    private void Awake()
    {
        _currentLaneIndex = 0;
        _currentTrack = FindObjectOfType<Track>();

        transform.position = _currentTrack.TrackLanes[_currentLaneIndex].position;
    }
    void Update()
    {
        var forwardDistance =  transform.rotation * Vector3.forward;
        var totalDistance = forwardDistance;

        if (Input.GetAxis("XRI_Left_Primary2DAxis_Horizontal") != 0 && !SwitchingLanes)
        {
            var direction = (int)Mathf.Sign(Input.GetAxis("XRI_Left_Primary2DAxis_Horizontal"));
            if (CanSwitchLanes(direction))
            { 
                SwitchLanes(direction);
                SwitchingLanes = true;
            }
        }
        if (SwitchingLanes == true)
        {
            if (OnCurrentTrack())
            {
                _timer = 0;
                SwitchingLanes = false;
            }
            else
            {
                _timer += Time.deltaTime;
                var horizontalDistance = new Vector3(_currentTrack.TrackLanes[_currentLaneIndex].transform.position.x, transform.position.y, transform.position.z) - transform.position;
                totalDistance += horizontalDistance * _horizontalSpeed;
            }
        }
        transform.Translate(totalDistance * Time.deltaTime );
    }

    private bool OnCurrentTrack()
    {
        return _currentTrack.TrackLanes[_currentLaneIndex].transform.position.x == transform.position.x || _timer > _horizontalMovementDelay;
    }

    private bool CanSwitchLanes(int direction)
    {
        if (_currentTrack.TrackLanes.Count > _currentLaneIndex + direction && _currentLaneIndex + direction >= 0)
            return true;
        else
            return false;
    }


    public void SwitchLanes(int direction)
    {
        _currentLaneIndex += direction;
        var nextLane = _currentTrack.TrackLanes[_currentLaneIndex];
    }
}
