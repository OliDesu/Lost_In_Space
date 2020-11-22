using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject objectToSpawn;
    public PlacementIndicator placementIndicator;

    public float spawnRate = 6f;
    float nextSpawn = 0f;
    // Start is called before the first frame update
    void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > nextSpawn)
        {

            GameObject cube = Instantiate(objectToSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation);
            cube.SetActive(true);
            
            nextSpawn = Time.time + spawnRate;

        }

        /*if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            GameObject cube = Instantiate(objectToSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation);
        }*/

    }
}
