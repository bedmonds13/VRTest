using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrackManager : MonoBehaviour
{
    [SerializeField] Track _trackPrefab;
    [SerializeField] int initialtTrackCount = 30;
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
        for (int i = 0; i < 30; i++)
        {
            nextTrack = SetTrack(_trackPrefab);
            listOfTracks.Add(nextTrack);    
            nextTrack.transform.parent = this.transform;
            nextTrack.name = "Track Clone: " + i;
            nextTrack.transform.parent = this.transform;
            FindObjectOfType<RunnerMovement>().SetCurrentTrack(_currentTrack);
        }
    }

    
    public Track SetTrack(Track prefab)
    {
        Track newTrack;
        if (_currentTrack != null)
        {
            var nextPosition = _currentTrack.transform.position + new Vector3(0,0, prefab.GetComponent<Renderer>().bounds.size.z);
            newTrack = Instantiate(_trackPrefab, nextPosition, listOfTracks[listOfTracks.Count-1].transform.rotation).GetComponent<Track>();
        }
        else
        { 
            newTrack = Instantiate(_trackPrefab, Vector3.zero, Quaternion.identity).GetComponent<Track>();
            _currentTrack = newTrack;
        }
        Debug.Log(" Setting track complete.");
        return newTrack;
    }
}
