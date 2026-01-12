using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsToggle : MonoBehaviour
{
    public GameObject boiler;
  
    public void ToggleSounds()
    {
      foreach (var sound in boiler.GetComponents<AudioSource>()) 
        sound.enabled = !sound.enabled;
    }
}
