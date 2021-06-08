using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class ClimbController : MonoBehaviour
{
    GameObject _xrRig;

    void Awake()
    {
        _xrRig = FindObjectOfType<XRRig>().gameObject;
    }

    public void Grab()
    {

    }
    public void Pull(Vector3 delta)
    {
        _xrRig.transform.Translate(delta);
    }
    public void Release()
    { }
}
