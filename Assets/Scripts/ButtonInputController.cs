using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonInputController : MonoBehaviour
{
    [SerializeField] UnityEvent ButtonDownEvent = new UnityEvent();
    [SerializeField] UnityEvent ButtonUpEvent = new UnityEvent();
    [SerializeField] GameObject righthand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("XRI_Right_TriggerButton"))
        {
            Debug.Log("Trigger down");
            ButtonDownEvent.Invoke();
        }
        else if (Input.GetButtonUp("XRI_Right_TriggerButton"))
        {
            Debug.Log("Trigger up");
            ButtonUpEvent.Invoke();
        }

    }
}
