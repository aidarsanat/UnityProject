// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.Audio;

// public class AudioSet : MonoBehaviour
// {
//     // private Light directionalLight; // Reference to your directional light
//     private AudioSource audioSource;
//     private float musicVolume = 1f; // Reference to your audio source

//     public Slider lightingSlider;
//     public Slider soundSlider;

//     // [ContextMenu("Play SFX")]
//     // public void PlaySfxAtPoint()
//     // {
//     //     AudioSource.PlayClipAtPoint(_clip, _audioPoint.position);
//     // }

//     void Start()
//     {
//         audioSource = GetComponent<AudioSource>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         audioSource.volume = musicVolume;
//     }

//     public void SetVolume(float vol)
//     {
//         musicVolume = vol;
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSet : MonoBehaviour 
{

    public AudioMixer mixer;
    public Slider slider;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    }

    public void SetLevel (float sliderValue)
    {
        mixer.SetFloat("MasterVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }

}

