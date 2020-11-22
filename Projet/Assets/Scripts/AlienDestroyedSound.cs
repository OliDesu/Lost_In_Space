using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienDestroyedSound : MonoBehaviour{

public static AudioClip alienDestroyedClip;
public static AudioSource alienDestroyedAudioSource;

  void Start()
  {
    alienDestroyedAudioSource = GetComponent<AudioSource>();

  }

  void Update() {

  }

  public void PlayAlienDestroyedSound(){
    alienDestroyedAudioSource.Play();
  }

}
