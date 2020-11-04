using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public GameObject shot;
    Vector2 shotPos;
    public float shotRate = 0.5f;
    float nextShot = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector2 position = transform.position;
            position.x -= 0.2f;
            transform.position = position;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector2 position = transform.position;
            position.x += 0.2f;
            transform.position = position;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector2 position = transform.position;
            position.y += 0.2f;
            transform.position = position;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector2 position = transform.position;
            position.y -= 0.2f;
            transform.position = position;
        }

        if (Input.GetButtonDown("Fire1") && Time.time > nextShot)
        {
            nextShot = Time.time + shotRate;
            fire();
        }
    }

    public void fire()
    {
        shotPos = transform.position;
        shotPos += new Vector2 (0,.4f);
        Instantiate (shot, shotPos, Quaternion.identity);
    }
}
