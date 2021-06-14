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

    public void PlayerTrigger()
    {
        listOfTracks[0].ReturnToPool(3f);
        listOfTracks.RemoveAt(0);
        SetTrack();
    }
    public void SetTrack() => SetTrack(_trackPrefab);
    
    void InitializeTracks()
    {
        Track nextTrack;
        for (int i = 0; i < initialTrackCount; i++)
        {
            nextTrack = SetTrack(_trackPrefab);
            nextTrack.name = "Track Clone: " + i;
            FindObjectOfType<RunnerMovement>().SetCurrentTrack(_currentTrack);
        }
    }
    Track SetTrack(Track prefab)
    {
        Track newTrack = _trackPrefab.Get<Track>();
        if (_currentTrack != null)
        {
            var nextPosition = listOfTracks[listOfTracks.Count - 1].transform.position + new Vector3(0,0, newTrack.GetComponent<BoxCollider>().bounds.size.z);
            newTrack.transform.position = nextPosition;
            newTrack.transform.rotation = Quaternion.identity;
        }
        else
            _currentTrack = newTrack;
        
        listOfTracks.Add(newTrack);    
        Debug.Log(" Setting track complete.");
        return newTrack;
    }
}
