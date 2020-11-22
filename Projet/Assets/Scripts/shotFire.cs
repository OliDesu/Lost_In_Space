using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotFire : MonoBehaviour
{

    public float speed = 5f;
    Rigidbody2D rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D> ();
        rigidbody.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy (gameObject, 3f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        alien alien = other.GetComponent<alien>();
        if (alien != null)
        {
            alien.TakeDamage(20);
            //FindObjectOfType<AlienDestroyedSound>().PlayAlienDestroyedSound();
            Destroy(gameObject);
        }
    }
}
