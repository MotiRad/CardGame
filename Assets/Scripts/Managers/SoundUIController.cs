using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundUIController : MonoBehaviour
{
    public Slider _musicSlider;
    public void ToggleMusic(){
        PlayMusicInBack.playMusicInBack.ToggleMusic();
        
    }
   /* public void ToggleSFX(){
        CardManager.instance.ToggleSFX();
    }*/
    public void MusicVolume(){
      //  CardManager.instance.MusicVolume(_musicSlider.value);

        _musicSlider.onValueChanged.AddListener(val => PlayMusicInBack.playMusicInBack.MusicVolume(val));
    }
    public void ToggleSound(){
        PlayMusicInBack.playMusicInBack.ToggleSound();
    }
    /* public void SFXVolume(){
       // CardManager.instance.SFXVolume(_sfxSlider.value);
          _sfxSlider.onValueChanged.AddListener(val => CardManager.instance.SFXVolume(val));


    }*/
}
