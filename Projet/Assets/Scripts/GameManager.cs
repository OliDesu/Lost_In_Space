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

    public AudioSource EndAudioSource;

    public void Start()
    {
        score = 0;
        //lives = 3;

        if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft){
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }

        EndAudioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft){
            Screen.orientation = ScreenOrientation.LandscapeLeft;
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
}
