using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSounds : MonoBehaviour
{

   public AudioSource audio;
   public AudioSource audio2;

   public void playButton()
   {
    audio.Play();
    audio2.Play();
   }
}
