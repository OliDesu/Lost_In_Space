using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Chat;
using Photon.Pun;
using ExitGames.Client.Photon;

public class PhotonChatManager : MonoBehaviour, IChatClientListener
{

    ChatClient chatClient;

    [SerializeField] string message;
    [SerializeField] public InputField inputField;
    [SerializeField] public Text text;

    // Start is called before the first frame update
    void Start()
    {
        chatClient = new ChatClient(this);
        chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, PhotonNetwork.AppVersion, new AuthenticationValues(PhotonNetwork.NickName));
    }

    // Update is called once per frame
    void Update()
    {
        chatClient.Service();
    }

    public void SetMessage(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return;
        }

        message = value;
        
    }

    public void SubmitMessage()
    {
        chatClient.PublishMessage("channelA", message);
        message = "";
        inputField.GetComponent<InputField>().text = "";
    }


    #region IChatClientListener Callbacks


    public void DebugReturn(DebugLevel level, string message)
    {
        
    }

    public void OnDisconnected()
    {

    }

    public void OnConnected()
    {
        chatClient.Subscribe("channelA");
    }

    public void OnChatStateChange(ChatState state)
    {

    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        string msgs = "";

        for (int i = 0; i < senders.Length; i++)
        {
            msgs = string.Format("{0}{1}: {2}\n",msgs, senders[i], messages[i]);
        }
        Debug.Log(msgs);
        text.text += msgs;
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {

    }

    public void OnSubscribed(string[] channels, bool[] results)
    {

    }

    public void OnUnsubscribed(string[] channels)
    {

    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {

    }

    public void OnUserSubscribed(string channel, string user)
    {

    }

    public void OnUserUnsubscribed(string channel, string user)
    {

    }

    #endregion
}
