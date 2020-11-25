using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject objectToSpawn;
    public PlacementIndicator placementIndicator;

    public float spawnRate = 10f;
    float nextSpawn;
    // Start is called before the first frame update
    void Start()
    {
        nextSpawn = 10f;
        placementIndicator = FindObjectOfType<PlacementIndicator>();
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (Time.time > nextSpawn)
        {
            Vector3 placement = placementIndicator.transform.position;
            for (int i = 0; i < 4 ;i++){               
                GameObject cube = Instantiate(objectToSpawn, placement, placementIndicator.transform.rotation);
                placement.x = placement.x + i *2;
                ARGameManager.cubes.Add(cube);
            }
           

            nextSpawn = Time.time + spawnRate;
        }

        /*if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            GameObject cube = Instantiate(objectToSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation);
        }*/

    }
}
