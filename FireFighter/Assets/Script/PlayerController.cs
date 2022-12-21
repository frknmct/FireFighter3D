using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float turnSpeed = 50f;
    public GameObject pipe;
    
    private void Update()
    {
        pipe.transform.Rotate(Vector3.up * turnSpeed * Input.GetAxis("Horizontal")  * Time.deltaTime);
        pipe.transform.Rotate(Vector3.right * turnSpeed * Input.GetAxis("Vertical")  * Time.deltaTime);
    }
}
