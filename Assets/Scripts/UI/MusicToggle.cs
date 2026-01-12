using UnityEngine;
using UnityEngine.Audio;

public class AudioToggle : MonoBehaviour
{
    public AudioSource musicSource;
    
    public void ToggleAudio()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Pause();
        }
        else
        {
            musicSource.Play();
        }
    }
}
