using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnTouch : MonoBehaviour
{
    public Vector3 lookAtPoint = Vector3.zero;
    
    void Update()
    {

        transform.LookAt(lookAtPoint);
        Debug.Log("Hello World");
    }
}
