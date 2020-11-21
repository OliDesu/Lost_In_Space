using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alien : MonoBehaviour
{

    public int health = 40;

    float speed = 0.4f;

    Rigidbody2D rigidbody;

    public GameObject speedBonus;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = transform.up * -speed;
    }

    void Update() {
        if (transform.position.y < -5.5f)
        {
            //FindObjectOfType<GameManager>().UpdateLives();
            //Destroy(gameObject);
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
            Score();
        }
    }

    public void Die()
    {
        int spawnChance = Random.Range(1,12);

        if (spawnChance == 10)
        {
            Vector2 pos = rigidbody.position;
            Instantiate(speedBonus, pos, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    public void Score()
    {
        FindObjectOfType<GameManager>().UpdateScore();
    }
}