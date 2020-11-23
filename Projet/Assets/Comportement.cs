using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Comportement : MonoBehaviour
{

    // Start is called before the first frame update
    GameObject target;
    void Start()
    {
        target = GameObject.Find("AR Camera");
    }
	
    
    void Update()
    {
    	Vector3 targetPosition = new Vector3(target.transform.position.x,transform.position.y,target.transform.position.z);
    	transform.LookAt(targetPosition);
    	transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 1f* Time.deltaTime);
	    if(targetPosition == transform.position){
            GameManager.RestartAR();
            SceneManager.LoadScene("Game Menu");
        }

    }
    
    public void OnMouseDown()
    {
        FindObjectOfType<GameManager>().UpdateScore();
    	Destroy(gameObject);
    }
}
