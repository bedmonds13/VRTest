using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabClimb : MonoBehaviour
{
    XRSimpleInteractable _interactable;
    ClimbController _climbController;
    bool isGrabbing = false;
    Vector3 handPosition;

    private void Start()
    {
        _interactable = GetComponent<XRSimpleInteractable>();
        _climbController = FindObjectOfType<ClimbController>();
    }
    private void Update()
    {
        if (isGrabbing == true)
        {
            Vector3 delta = handPosition - InteractorPosition();
            _climbController.Pull(delta);
            handPosition = InteractorPosition();

        }
    }

    public void Grab()
    {
        isGrabbing = true;
        Debug.Log("Interacting with" + gameObject.name);
        handPosition = InteractorPosition();
        _climbController.Grab();
    }
    public Vector3 InteractorPosition()
    {
        List<XRBaseInteractor> interactors = _interactable.hoveringInteractors;
        if (interactors.Count > 0)
            return interactors[0].transform.position;
        else 
            return handPosition;
    }
    public void Release()
    {
        isGrabbing = false;
        _climbController.Release();

    }
}
