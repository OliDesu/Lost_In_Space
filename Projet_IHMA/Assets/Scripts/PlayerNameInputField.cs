using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;
using Photon.Realtime;

[RequireComponent(typeof(InputField))]
public class PlayerNameInputField : MonoBehaviour
{

    #region Private Constants

    const string playerNamePrefKey = "PlayerName";

    #endregion


    #region MonoBehaviour Callbacks


    // Start is called before the first frame update
    void Start()
    {
        

        string defaultName = string.Empty;
        InputField _inputField = GetComponent<InputField>();

        if (_inputField != null)
        {
            if (PlayerPrefs.HasKey(playerNamePrefKey))
            {
                defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                _inputField.text = defaultName;
            }
        }

        PhotonNetwork.NickName = defaultName;
    }

    #endregion

    
    #region Public Methods


    public void SetPlayerName(string value)
    {

        if (string.IsNullOrEmpty(value))
        {
            Debug.LogError("Player Name is null or empty");
            return;
        }

        PhotonNetwork.NickName = value;

        PlayerPrefs.SetString(playerNamePrefKey,value);
    }

    #endregion
}
