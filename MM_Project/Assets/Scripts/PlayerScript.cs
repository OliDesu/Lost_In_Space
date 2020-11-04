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

    protected bool shoot;
    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joyButton = FindObjectOfType<JoyButtonScript>();
    }

    // Update is called once per frame
    void Update()
    {

        var rigidbody = GetComponent<Rigidbody2D>();


        rigidbody.velocity = new Vector2(joystick.Horizontal * 5f + Input.GetAxis("Horizontal") * 5f, joystick.Vertical * 5f + Input.GetAxis("Vertical") * 5f);

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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
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
}
