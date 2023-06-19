using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMusicInBack : MonoBehaviour
{
     public static PlayMusicInBack playMusicInBack;
     public Sound[] musicSound;
     private bool mute=false;
      private bool muteMusic=false;
    public AudioSource musicSource;
   
    void Start()
    {
        if(playMusicInBack==null){
            playMusicInBack=this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
        PlayMusic("BGSound");

        if(!PlayerPrefs.HasKey("mutedMusic")){
            PlayerPrefs.SetInt("mutedMusic",0);
            loadTM();
        }
        else{
            loadTM();
        }

         if(!PlayerPrefs.HasKey("mutedSound")){
            PlayerPrefs.SetInt("mutedSound",0);
            loadTS();
        }
        else{
            loadTS();
        }
        AudioListener.pause=mute;
        musicSource.mute=muteMusic;
    }
    public void PlayMusic(string name){
        Sound s = Array.Find(musicSound,x=> x.name == name);
        if (s==null){
            Debug.Log("Sound not found");
        }  
        else{
            musicSource.clip=s.clip;
            musicSource.Play();
        }

    }
   
     public void ToggleMusic(){
        if (muteMusic==false){

            muteMusic=true;
            musicSource.mute=true;
        }
        else{
              muteMusic=false;
            musicSource.mute=false;

        }
        saveTM();
       // musicSource.mute=!musicSource.mute;
    }
    public void ToggleSound(){
        if (mute==false){

            mute=true;
            AudioListener.pause=true;
        }
        else{
              mute=false;
            AudioListener.pause=false;

        }
        saveTS();
    }
    public void MusicVolume(float volume){
       musicSource.volume=volume;
      // AudioListener.volume=volume;

    }
    private void loadTS(){
        mute=PlayerPrefs.GetInt("mutedSound")==1;

    }
    private void saveTS(){

        PlayerPrefs.SetInt("mutedSound",mute?1:0);
    }
    private void loadTM(){
        mute=PlayerPrefs.GetInt("mutedMusic")==1;

    }
    private void saveTM(){

        PlayerPrefs.SetInt("mutedMusic",mute?1:0);
    }
}
