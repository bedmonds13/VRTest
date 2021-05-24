using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    [SerializeField] GameObject balloon;
    [SerializeField] float force;
    [SerializeField] float growthRate = 0.1f;
    
    GameObject heldBalloon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        if (heldBalloon != null)
        {
            heldBalloon.transform.localScale += new Vector3(growthRate,growthRate,growthRate);
        }
        
    }

    public void ReleaseBalloon()
    {
        heldBalloon.transform.parent = null;
        heldBalloon.GetComponent<Rigidbody>().AddForce(Vector3.up * force);
        Destroy(heldBalloon, 10f);
        heldBalloon = null;
    }

    public void CreateBalloon(GameObject hand)
    {

        heldBalloon = Instantiate(balloon, hand.transform.position, Quaternion.identity);
        heldBalloon.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f) * Time.deltaTime;
        heldBalloon.transform.parent = hand.transform;
    }
}
