using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRandomScript : MonoBehaviour
{

  float speed = 0.4f;
  float bonusTime = 10.0f;


  Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = transform.up * -speed;

        if (transform.localScale == new Vector3(0.6f, 0.6f, 0))
        {
            if (Input.deviceOrientation == DeviceOrientation.Portrait)
            {
                transform.localScale += new Vector3(-0.3f, -0.3f, 0);
            }
        }

        if (transform.localScale == new Vector3(0.3f, 0.3f, 0))
        {
            if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft)
            {
                transform.localScale += new Vector3(0.3f, 0.3f, 0);
            }
        }
    }

    public void PickUp()
    {
        Destroy(gameObject);
    }

    void Update() {
      if (transform.localScale == new Vector3(0.6f, 0.6f, 0))
      {
          if (Input.deviceOrientation == DeviceOrientation.Portrait)
          {
              transform.localScale += new Vector3(-0.3f, -0.3f, 0);
          }
      }

      if (transform.localScale == new Vector3(0.3f, 0.3f, 0))
      {
          if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft)
          {
              transform.localScale += new Vector3(0.3f, 0.3f, 0);
          }
      }
    }
}
