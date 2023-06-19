using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueSaveing : MonoBehaviour
{
    
    // Start is called before the first frame update
    [SerializeField] private Slider _slidermusic;
    void Start()
    {
        LoadValue();
       
    }

    public void SaveVolume()
    {
        float volumevalue=_slidermusic.value;
       // float volumevaluesfx=_slidersfx.value;
        PlayerPrefs.SetFloat("VolumeValue",volumevalue);
        //PlayerPrefs.SetFloat("VolumeValuesfx",volumevaluesfx);
        LoadValue();
    }

    public void LoadValue() {
        float volumevalue = PlayerPrefs.GetFloat("VolumeValue");
        //float volumevaluesfx = PlayerPrefs.GetFloat("VolumeValuesfx");
        _slidermusic.value=volumevalue;
       // _slidersfx.value=volumevaluesfx;

        PlayMusicInBack.playMusicInBack.MusicVolume(volumevalue);
       // CardManager.instance.SFXVolume(volumevaluesfx);

    }
}
