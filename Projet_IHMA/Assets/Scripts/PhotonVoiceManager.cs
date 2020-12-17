using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;
using Photon.Voice.Unity;
using Photon.Voice.PUN;

public class PhotonVoiceManager : MonoBehaviour
{

    bool talk = false;

    public Recorder recorder;

    // Start is called before the first frame update
    void Start()
    {
        PhotonVoiceNetwork.Instance.Client.GlobalInterestGroup = 0;
        this.recorder = GetComponent<Recorder>();
    }

    public void Talk()
    {
        if (!talk)
        {
            recorder.TransmitEnabled = true;
        } else {
            recorder.TransmitEnabled = false;
        }
    }

}
