using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static int score = 0;
    public static int lives = 3;

    bool gameHasEnded = false;

    public static List<GameObject> aliens = new List<GameObject>();

    public float leftBorder;
    public float rightBorder;
    public float upperBorder;
    public float bottomBorder;

    public void Start()
    {
        score = 0;
        //lives = 3;

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
    }

    void Restart()
    {
        foreach (GameObject alien in aliens)
        {
            Destroy(alien);
        }
        SceneManager.LoadScene("Game Over");
    }
}
