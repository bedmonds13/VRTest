using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoseToggle : MonoBehaviour
{
    bool HoseOn = false;
    ParticleSystem hose;

    private void Start()
    {
        hose = GetComponentInChildren<ParticleSystem>();
    }
    public void ToggleHose()
    {
        if (HoseOn)
        {
            hose.Stop();
        }
        else
        {
            hose.Play();
        }
        HoseOn = !HoseOn;
            
    }
}
