using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static int score = 0;
    public static int lives = 3;

    bool gameHasEnded = false;

    public static List<GameObject> aliens = new List<GameObject>();

    public void Start()
    {
        score = 0;
        //lives = 3;
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
