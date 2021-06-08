using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlideLocomotion : MonoBehaviour
{
    public Transform rigRoot;

    [SerializeField] float _velocity = 2;
    [SerializeField] float _rotateSpeed = 2;


    private void Start()
    {
        if (rigRoot == null)
            rigRoot = transform;
        
    }
    private void Update()
    {
        VerticalMovement();
        HorizontatlMovement();
    }

    private void HorizontatlMovement()
    {
        float right = Input.GetAxis("XRI_Right_Primary2DAxis_Horizontal");
        if(right != 0)
        {
            var direction = right * _rotateSpeed;
            transform.Rotate(0, direction, 0);
        }
    }

    private void VerticalMovement()
    {
        float forward = Input.GetAxis("XRI_Right_Primary2DAxis_Vertical");
        if (forward != 0f)
        {
            Vector3 moveDirection = Vector3.forward;
            moveDirection *= -forward * _velocity * Time.deltaTime;

            rigRoot.Translate(moveDirection);

        }
    }
}
