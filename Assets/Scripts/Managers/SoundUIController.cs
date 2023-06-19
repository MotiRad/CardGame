using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundUIController : MonoBehaviour
{
    public static SoundUIController soundUIController;
    public Slider _musicSlider;
    public Image SoundOn,SoundOf,MusicOn,MusicOf;
    public void ToggleMusic(){
        PlayMusicInBack.playMusicInBack.ToggleMusic();
        UpdateBTNMusicIcon();
       
        
    }
   /* public void ToggleSFX(){
        CardManager.instance.ToggleSFX();
    }*/
    private void Start() {
        UpdateBTNMusicIcon();
        UpdateBTNSoundIcon();
    }
    public void MusicVolume(){
      //  CardManager.instance.MusicVolume(_musicSlider.value);

        _musicSlider.onValueChanged.AddListener(val => PlayMusicInBack.playMusicInBack.MusicVolume(val));
    }
    public void ToggleSound(){
        PlayMusicInBack.playMusicInBack.ToggleSound();
        UpdateBTNSoundIcon();
        
       
    }
    public void UpdateBTNMusicIcon(){
         bool muteMusic= PlayMusicInBack.playMusicInBack.muteMusic;

       
        if(muteMusic==false)
        {
             MusicOn.enabled=true;
             MusicOf.enabled=false;

        }
        else{
             MusicOn.enabled=false;
             MusicOf.enabled=true;
        }

    }
    public void UpdateBTNSoundIcon(){
        bool mute= PlayMusicInBack.playMusicInBack.mute;

        
        if(mute==false)
        {
             SoundOn.enabled=true;
             SoundOf.enabled=false;

        }
        else{
            SoundOn.enabled=false;
             SoundOf.enabled=true;
        }

    }
    /* public void SFXVolume(){
       // CardManager.instance.SFXVolume(_sfxSlider.value);
          _sfxSlider.onValueChanged.AddListener(val => CardManager.instance.SFXVolume(val));


    }*/
}
