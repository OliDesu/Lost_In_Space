using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBonusScript : MonoBehaviour
{

float speed = 0.4f;
float bonusTime = 10.0f;


Rigidbody2D rigidbody;

  void Start()
  {
      rigidbody = GetComponent<Rigidbody2D>();
      rigidbody.velocity = transform.up * -speed;
  }

  public void PickUp()
  {
      Destroy(gameObject);
  }

  void Update() {
  }
}
