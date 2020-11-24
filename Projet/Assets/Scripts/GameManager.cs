using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static int score = 0;
    public static int lives = 3;

    bool gameHasEnded = false;

    public static List<GameObject> aliens = new List<GameObject>();
    public static List<GameObject> speedBonus = new List<GameObject>();
    public static List<GameObject> slowAliens = new List<GameObject>();
    public static List<GameObject> destroyRandom = new List<GameObject>();
    public static List<GameObject> cubes = new List<GameObject>();

    public AudioSource EndAudioSource;

    public float leftBorder;
    public float rightBorder;
    public float upperBorder;
    public float bottomBorder;

    public bool isSlowed = false;
    float bonusTimeSlowAliens = 10.0f;

    public void Start()
    {
        score = 0;
        //lives = 3;
        EndAudioSource = GetComponent<AudioSource>();

        if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft){
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }

        if (Input.deviceOrientation == DeviceOrientation.Portrait){
            Screen.orientation = ScreenOrientation.Portrait;
        }
        Vector3 myViewPos = Camera.main.WorldToViewportPoint(FindObjectOfType<PlayerScript>().transform.position);
        Vector2 screenBottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, myViewPos.z));
        Vector2 screenTopRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, myViewPos.z));
        leftBorder = screenBottomLeft.x;
        rightBorder = screenTopRight.x;
        bottomBorder = screenBottomLeft.y;
        upperBorder = screenTopRight.y;
    }

    private void Update() {
        if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft){
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }

        if (Input.deviceOrientation == DeviceOrientation.Portrait){
            Screen.orientation = ScreenOrientation.Portrait;
        }

        Vector3 myViewPos = Camera.main.WorldToViewportPoint(FindObjectOfType<PlayerScript>().transform.position);
        Vector2 screenBottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, myViewPos.z));
        Vector2 screenTopRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, myViewPos.z));
        leftBorder = screenBottomLeft.x;
        rightBorder = screenTopRight.x;
        bottomBorder = screenBottomLeft.y;
        upperBorder = screenTopRight.y;

        if (isSlowed){

          bonusTimeSlowAliens -= 3*Time.deltaTime;

          if (bonusTimeSlowAliens <= 0.0f){
            isSlowed = false;
            SpawnerScript.slowBonusSpawned = false;

          }

        }
    }

    public void UpdateScore()
    {
        score += 10;
    }

    //////////////////////////////
    // If you wish to add lives //
    //////////////////////////////

    /*public void UpdateLives()
    {
        lives--;
        if (lives <= 0)
        {
            EndGame();
        }
    }*/

    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Invoke("Restart", 0.5f);
        }
        EndAudioSource.Play();
    }

    void Restart()
    {
        foreach (GameObject alien in aliens)
        {
            Destroy(alien);
        }
        SceneManager.LoadScene("Game Over");
    }

    public static void  RestartAR(){
        foreach (GameObject cube in cubes)
        {
            Destroy(cube);
            Debug.Log("CC LA STREET");
        }
        SceneManager.LoadScene("Game Menu");
    }
}
