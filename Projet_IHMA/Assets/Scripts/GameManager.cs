using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
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

    public GameObject playerPrefab;



    #region MonoBehaviour Callbacks

    public void Start()
    {

        score = 0;
        //lives = 3;
        EndAudioSource = GetComponent<AudioSource>();

        if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft)
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }

        if (Input.deviceOrientation == DeviceOrientation.Portrait)
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }

        if (SceneManager.GetActiveScene().name == "Room for 2")
        {
            if (playerPrefab == null)
            {
                Debug.LogError("<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this);
            }
            else
            {
                PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(0f, -4f, 0f), Quaternion.identity, 0);
            }
            Vector3 myViewPos = Camera.main.WorldToViewportPoint(FindObjectOfType<PlayerScript>().transform.position);
            Vector2 screenBottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, myViewPos.z));
            Vector2 screenTopRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, myViewPos.z));
            leftBorder = screenBottomLeft.x;
            rightBorder = screenTopRight.x;
            bottomBorder = screenBottomLeft.y;
            upperBorder = screenTopRight.y;
        }

    }

    private void Update()
    {

        if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft)
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }

        if (Input.deviceOrientation == DeviceOrientation.Portrait)
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }

        if (SceneManager.GetActiveScene().name == "Room for 2")
        {
            Vector3 myViewPos = Camera.main.WorldToViewportPoint(FindObjectOfType<PlayerScript>().transform.position);
            Vector2 screenBottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, myViewPos.z));
            Vector2 screenTopRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, myViewPos.z));
            leftBorder = screenBottomLeft.x;
            rightBorder = screenTopRight.x;
            bottomBorder = screenBottomLeft.y;
            upperBorder = screenTopRight.y;
        }

        if (isSlowed)
        {

            bonusTimeSlowAliens -= 3 * Time.deltaTime;

            if (bonusTimeSlowAliens <= 0.0f)
            {
                isSlowed = false;
                SpawnerScript.slowBonusSpawned = false;

            }

        }
    }

    #endregion




    #region Private Methods


    void LoadArena()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
        }
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            Debug.LogFormat("PhotonNetwork : Loading Level : {0}", 2);
            PhotonNetwork.LoadLevel("Room for " + 2);
        }

    }


    #endregion






    #region Public Methods

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
        PlayerPrefs.SetInt("Score", score);
        SceneManager.LoadScene("Game Over");
    }

    public static void RestartAR()
    {
        foreach (GameObject cube in cubes)
        {
            Destroy(cube);
        }
        SceneManager.LoadScene("Game Menu");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    #endregion






    #region Photon Callbacks

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("Launcher");
    }

    public override void OnPlayerEnteredRoom(Player other)
    {
        Debug.LogFormat("OnPlayerEnteredRoom() {0}", other.NickName);

        if (PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat("OnPlayerEnterdRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient);

            LoadArena();
        }
    }

    public override void OnPlayerLeftRoom(Player other)
    {
        Debug.LogFormat("OnPlayerLeftRoom() {0}", other.NickName);

        if (PhotonNetwork.IsMasterClient)
        {
            SceneManager.LoadScene("Launcher");
        }
    }

    #endregion
}
