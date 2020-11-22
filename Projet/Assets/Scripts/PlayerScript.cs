using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [SerializeField] Transform target;

    public GameObject shot;
    public float shotRate = 0.3f;
    float nextShot = 0.0f;
    protected Joystick joystick;
    protected JoyButtonScript joyButton;

    float movementSpeed = 5f;

    float bonusTimeSpeed = 10.0f;

    float bonusTimeSlowAliens = 10.0f;

    bool allSlowed = false;

    protected bool shoot;

    public AudioSource BonusAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joyButton = FindObjectOfType<JoyButtonScript>();
        BonusAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        var rigidbody = GetComponent<Rigidbody2D>();


        rigidbody.velocity = new Vector2(joystick.Horizontal * movementSpeed + Input.GetAxis("Horizontal") * movementSpeed, joystick.Vertical * movementSpeed + Input.GetAxis("Vertical") * movementSpeed);

        if (rigidbody.transform.position.x >= 10f){
            rigidbody.transform.position = new Vector2(10f, rigidbody.transform.position.y);
        }

        if (rigidbody.transform.position.x <= -10f){
            rigidbody.transform.position = new Vector2(-10f, rigidbody.transform.position.y);
        }

        if (rigidbody.transform.position.y >= 5f){
            rigidbody.transform.position = new Vector2(rigidbody.transform.position.x, 5f);
        }

        if (rigidbody.transform.position.y <= -5f){
            rigidbody.transform.position = new Vector2(rigidbody.transform.position.x, -5f);
        }

        //SHOOT
        if (!shoot && joyButton.Pressed)
        {
            shoot = true;
            if (Time.time > nextShot)
            {
                nextShot = Time.time + shotRate;
                fire();
            }
        }

        if (shoot && !joyButton.Pressed)
        {
            shoot = false;
        }

        //INCREASE THE SPEED OF THE PLAYER
        if (movementSpeed != 5f)
        {
            bonusTimeSpeed -= Time.deltaTime;

            if (bonusTimeSpeed <= 0.0f)
            {
                EndSpeedBonus();
            }
        }

        //SLOW ALIENS WHEN BONUS IS PICKED
        if (allSlowed == true)
        {
          foreach(GameObject a in GameManager.aliens){
            if(a.GetComponent<alien>()!=null){
              alien al = a.GetComponent<alien>();
              al.isSlowed = true;
            }
          }
            bonusTimeSlowAliens -= 3*Time.deltaTime;

            if (bonusTimeSlowAliens <= 0.0f)
            {
              foreach(GameObject a in GameManager.aliens){
                if(a.GetComponent<alien>()!=null){
                  alien al = a.GetComponent<alien>();
                  if(al.alreadySlowed){
                    al.stopSlow = true;
                  }
                }
              }
              allSlowed = false;
              SpawnerScript.slowBonusSpawned = false;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {

      //COLLIDE WHITH SPEED BONUS
        if (other.name == "SpeedBonus(Clone)")
        {
            SpeedBonusScript speedBonus = other.GetComponent<SpeedBonusScript>();

            if (speedBonus != null)
            {
                movementSpeed += 3f;
                speedBonus.PickUp();
            }
        }

        //COLLIDE WHITH SLOW ALIEN BONUS
        if (other.name == "SlowAlien(Clone)")
        {
            SlowAlien slowAlien = other.GetComponent<SlowAlien>();

            if (slowAlien != null)
            {
              //Slow every alien
              allSlowed = true;
              slowAlien.PickUp();
              BonusAudioSource.Play();
            }
        }

        //COLLIDE WHITH DESTROY ALIEN BONUS
        if (other.name == "DestroyRandom(Clone)")
        {
            DestroyRandomScript destroyRandom = other.GetComponent<DestroyRandomScript>();

            if (destroyRandom != null)
            {
              int i = 0;
              while(i < 10){
                  alien a = FindObjectOfType<alien>();
                  if(a.GetComponent<alien>()!=null){
                    a.Die();
                  }
                i = i+1;
              }

              SpawnerScript.destroyBonusSpawned = false;
              destroyRandom.PickUp();
              BonusAudioSource.Play();
            }

        }

        alien alien = other.GetComponent<alien>();

        if (alien != null)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    public void fire()
    {
        Vector2 shotPos = target.position;
        shotPos += new Vector2(0, .4f);
        Instantiate(shot, shotPos, Quaternion.identity);
    }

    public void EndSpeedBonus()
    {
        movementSpeed -= 3f;
    }
}
