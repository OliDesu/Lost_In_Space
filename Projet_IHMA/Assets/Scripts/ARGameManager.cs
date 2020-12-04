using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARGameManager : MonoBehaviour
{

    public static int score = 0;

    public static List<GameObject> cubes = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        score = 0;

        if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft){
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }

        if (Input.deviceOrientation == DeviceOrientation.Portrait){
            Screen.orientation = ScreenOrientation.Portrait;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft){
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }

        if (Input.deviceOrientation == DeviceOrientation.Portrait){
            Screen.orientation = ScreenOrientation.Portrait;
        }
    }

    public void UpdateScore()
    {
        score += 10;
    }

    public static void  RestartAR(){
        foreach (GameObject cube in cubes)
        {
            Destroy(cube);
        }
        SceneManager.LoadScene("Game Menu");
    }
}
