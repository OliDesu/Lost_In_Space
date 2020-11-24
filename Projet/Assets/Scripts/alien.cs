using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alien : MonoBehaviour
{

    public int health = 40;

    float speed = 0.4f;

    Rigidbody2D rigidbody;

    public GameObject speedBonus;

    public bool alreadySlowed = false;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = transform.up * -speed;

        if (transform.localScale == new Vector3(5f, 5f, 0))
        {
            if (Input.deviceOrientation == DeviceOrientation.Portrait)
            {
                transform.localScale += new Vector3(-2f, -2f, 0);
            }
        }

        if (transform.localScale == new Vector3(3f, 3f, 0))
        {
            if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft)
            {
                transform.localScale += new Vector3(2f, 2f, 0);
            }
        }
    }

    void Update()
    {
        if (transform.localScale == new Vector3(5f, 5f, 0))
        {
            if (Input.deviceOrientation == DeviceOrientation.Portrait)
            {
                transform.localScale += new Vector3(-2f, -2f, 0);
            }
        }

        if (transform.localScale == new Vector3(3f, 3f, 0))
        {
            if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft)
            {
                transform.localScale += new Vector3(2f, 2f, 0);
            }
        }


        if(!alreadySlowed){
          if(FindObjectOfType<GameManager>().isSlowed){
              speed -= 0.2f;
              rigidbody.velocity = transform.up * -speed;
              alreadySlowed = true;
            }
        }

        else{
          if(!FindObjectOfType<GameManager>().isSlowed){
            speed += 0.2f;
            rigidbody.velocity = transform.up * -speed;
            alreadySlowed = false;
          }
        }

        if (transform.position.y < FindObjectOfType<GameManager>().bottomBorder)
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
        FindObjectOfType<AlienDestroyedSound>().PlayAlienDestroyedSound();
        GameManager.aliens.Remove(gameObject);
        Destroy(gameObject);
    }

    public void Score()
    {
        FindObjectOfType<GameManager>().UpdateScore();
    }
}
