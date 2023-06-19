using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{
    // Start is called before the first frame update
    

    void Start()
    {
        float volumevalue = PlayerPrefs.GetFloat("VolumeValue");
        float volumevaluesfx = PlayerPrefs.GetFloat("VolumeValuesfx");
        

        PlayMusicInBack.playMusicInBack.MusicVolume(volumevalue);
       // CardManager.instance.SFXVolume(volumevaluesfx);
    }

    
}
