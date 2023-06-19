using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    
    public static SoundManager Instance;
    private void Awake() {
        if(Instance==null)
        {
            Instance=this;
            DontDestroyOnLoad(gameObject);
            return;

        }
        else{
            Destroy(gameObject); 
        }
    }
    
    public void ChangeMasterValue(float value)
    {
        AudioListener.volume=value;
        
        
    }
    
}
