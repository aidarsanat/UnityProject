using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // public Slider soundSlider;
    // public Slider lightSlider;

    // private void Start()
    // {
    //     // Set default values for sound and light sliders
    //     soundSlider.value = PlayerPrefs.GetFloat("SoundVolume", 1f);
    //     lightSlider.value = PlayerPrefs.GetFloat("LightIntensity", 1f);
    // }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // public void OpenSoundSettings()
    // {
    //     // Implement sound settings logic here
    //     // For simplicity, we'll just print a message for now
    //     Debug.Log("Open Sound Settings");
    // }

    // public void OpenLightSettings()
    // {
    //     // Implement light settings logic here
    //     // For simplicity, we'll just print a message for now
    //     Debug.Log("Open Light Settings");
    // }

    public void ExitGame()
    {
        // Save player preferences before exiting
        PlayerPrefs.Save();
        Application.Quit();
    }

//     public void UpdateSoundVolume(float volume)
//     {
//         // Implement sound volume adjustment logic here
//         // For simplicity, we'll just set PlayerPrefs for now
//         PlayerPrefs.SetFloat("SoundVolume", volume);
//     }

//     public void UpdateLightIntensity(float intensity)
//     {
//         // Implement light intensity adjustment logic here
//         // For simplicity, we'll just set PlayerPrefs for now
//         PlayerPrefs.SetFloat("LightIntensity", intensity);
//     }
}
