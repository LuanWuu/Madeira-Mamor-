using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMixer : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    // Start is called before the first frame update
    public void SetMasterVolume(float intensity){
        mixer.SetFloat("Master", 20f * Mathf.Log10(intensity));
    }
    public void SetMusicVolume(float intensity){
        mixer.SetFloat("Music", 20f * Mathf.Log10(intensity));
    }
    public void SetEffectsVolume(float intensity){
        mixer.SetFloat("Effects", 20f * Mathf.Log10(intensity));
    }
}
