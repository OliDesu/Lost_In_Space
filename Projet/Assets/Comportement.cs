using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	;
	transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 1f* Time.deltaTime);
	if (Input.GetMouseButtonDown(0))
         { 
             Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
             RaycastHit hit;
             if (Physics.Raycast(ray, out hit))
              {
                 Destroy(hit.collider.gameObject);
              }
          }


    }
}
