using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RunnerMovement : MonoBehaviour
{
    public Track CurrentTrack => _currentTrack;
    public bool SwitchingLanes { get; private set; }


    [SerializeField] float _forwardSpeed = 2f;
    [SerializeField] float _horizontalSpeed = 2f;
    [SerializeField] float  _jumpForce = 10;
   
    Rigidbody rb;
    Track  _currentTrack;
    int _currentLaneIndex;
   
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _currentLaneIndex = 0;
        transform.position = _currentTrack.TrackLanes[_currentLaneIndex].position;
    }
    void Update()
    {
        var forwardDistance =  transform.rotation * Vector3.forward * _forwardSpeed;
        var totalDistance = forwardDistance;
        
        //Calcualte velocity and add from current position.
        transform.Translate(totalDistance * Time.deltaTime );

        
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
                SwitchingLanes = false;
            }
            else
            {
                var horizontalDistance = new Vector3(_currentTrack.TrackLanes[_currentLaneIndex].transform.position.x, transform.position.y, transform.position.z) - transform.position;
                var nextLanePosition = transform.position + horizontalDistance;
                transform.position = Vector3.Lerp(transform.position, nextLanePosition, _horizontalSpeed * Time.deltaTime);

            }
        }
        else if (Input.GetButtonDown("XRI_Right_PrimaryButton") == true)
        {
            Debug.Log("Jump Button pressed");
            Jump();
        }
    }


    public bool IsBetween(float testValue, float bound1, float bound2) => (testValue >= Math.Min(bound1, bound2) && testValue <= Math.Max(bound1, bound2));
    public void SwitchLanes(int direction)
    {
        _currentLaneIndex += direction;
        var nextLane = _currentTrack.TrackLanes[_currentLaneIndex];
    }
    
    void Jump() => rb.AddForce(transform.up * _jumpForce, ForceMode.Force );
    
    bool OnCurrentTrack()
    {
        return IsBetween(transform.position.x, _currentTrack.TrackLanes[_currentLaneIndex].transform.position.x - 0.1f, _currentTrack.TrackLanes[_currentLaneIndex].transform.position.x + 0.1f);
    }

    bool CanSwitchLanes(int direction)
    {
        if (_currentTrack.TrackLanes.Count > _currentLaneIndex + direction && _currentLaneIndex + direction >= 0)
            return true;
        else
            return false;
    
    }
    public void SetCurrentTrack(Track track)
    {
        _currentTrack = track;
        Debug.Log("Player has new track added.");
    }

}
