using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotSound : MonoBehaviour{

public AudioClip shotClip;
public AudioSource shotAudioSource;

  void Start()
  {
    shotAudioSource = GetComponent<AudioSource>();

  }

  void Update() {

  }

  void PlayShotSound(){
    shotAudioSource.clip = shotClip;
    shotAudioSource.Play();
  }

}
