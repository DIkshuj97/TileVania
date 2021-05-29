using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeslider;
    [SerializeField] float defaultvolume = 0.8f;

    [SerializeField] Slider difficultyslider;
    [SerializeField] float defaultdifficulty = 1f;


    // Start is called before the first frame update
    void Start()
    {
       //  volumeslider.value = PlayerPrefsController.GetMasterVolume();
        difficultyslider.value = PlayerPrefsController.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        
        /* var musicPlayer = FindObjectOfType<MusicStartScreen>();
         if (musicPlayer)
         {
             musicPlayer.SetVolume(volumeslider.value);
         }

         else
         {
             Debug.LogWarning("no music");
         }*/
    }

    public void SaveAndExit()
    {
       // PlayerPrefsController.SetMasterVolume(volumeslider.value);
        PlayerPrefsController.SetDifficulty(difficultyslider.value);
        FindObjectOfType<Menu>().MainMenulevel();
    }

    public void SetDefault()
    {
       // volumeslider.value = defaultvolume;
        difficultyslider.value = defaultdifficulty;
    }
}
