using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Movement());
    }
    IEnumerator Movement()
    {
        while (true)
        {
            SetRandomPosition();
            yield return new WaitForSeconds(5f);
        }
    }

    void SetRandomPosition()
    {
        float x = Random.Range(-0.5f, 5.0f);
        float z = Random.Range(-0.5f, 5.0f);
        Debug.Log("x:" + x + " z:" + z);
        transform.position += new Vector3(x, 0, z);
    }
}
