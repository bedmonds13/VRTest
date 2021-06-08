using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookMoveTo : MonoBehaviour
{
    [SerializeField]private GameObject ground;

    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray;
        RaycastHit hit;
        GameObject hitGameobject;

        Debug.DrawRay(camera.position, camera.rotation * Vector3.forward * 100.0f,Color.blue);
        ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        if(Physics.Raycast(ray,out hit))
        {
            hitGameobject = hit.collider.gameObject;
            if(hitGameobject == ground)
            {
                transform.position = hit.point;
            }
        }
    }
}
