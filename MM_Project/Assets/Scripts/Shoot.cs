using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Shoot : MonoBehaviour
{

    [SerializeField] Transform target;
   
    public GameObject shot;
    public float shotRate = 0.3f;
    float nextShot = 0.0f;

    private void OnMouseDown()
    {
        if (Time.time > nextShot)
        {
            nextShot = Time.time + shotRate;
            fire();
        }
    }

    public void fire()
    {
        Vector2 shotPos = target.position;
        shotPos += new Vector2 (0,.4f);
        Instantiate (shot, shotPos, Quaternion.identity);
    }
}
