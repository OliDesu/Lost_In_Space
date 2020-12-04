using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Room for 2");
    }

    public void ConnectToRoom()
    {
        SceneManager.LoadScene("Launcher");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Game Menu");
    }

    public void PlayARGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
