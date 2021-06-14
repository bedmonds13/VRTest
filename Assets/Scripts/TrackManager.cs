using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrackManager : MonoBehaviour
{
    [SerializeField] Track _trackPrefab;
    [SerializeField] int initialTrackCount = 30;
    [SerializeField]List<Track> listOfTracks = new List<Track>();

    Track _currentTrack;
    public static TrackManager Instance;
    void Awake()
    {
        Instance = this;
        InitializeTracks();
    }
    

    void InitializeTracks()
    {
        Track nextTrack;
        for (int i = 0; i < initialTrackCount; i++)
        {
            nextTrack = SetTrack(_trackPrefab);
            nextTrack.name = "Track Clone: " + i;
            nextTrack.transform.parent = this.transform;
            FindObjectOfType<RunnerMovement>().SetCurrentTrack(_currentTrack);
        }
    }

    public void SetTrack()
    {
        SetTrack(_trackPrefab);
    }
    Track SetTrack(Track prefab)
    {
        Track newTrack;
        if (_currentTrack != null)
        {
            newTrack = Instantiate(_trackPrefab);
            var nextPosition = listOfTracks[listOfTracks.Count - 1].transform.position + new Vector3(0,0, newTrack.GetComponent<BoxCollider>().bounds.size.z);
            newTrack.transform.position = nextPosition;
            newTrack.transform.rotation = Quaternion.identity;
            newTrack = newTrack.GetComponent<Track>();
        }
        else
        { 
            newTrack = Instantiate(_trackPrefab, Vector3.zero, Quaternion.identity).GetComponent<Track>();
            _currentTrack = newTrack;
        }
        listOfTracks.Add(newTrack);    
        newTrack.transform.parent = this.transform;
        Debug.Log(" Setting track complete.");
        return newTrack;
    }
}
