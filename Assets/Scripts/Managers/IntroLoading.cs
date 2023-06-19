using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroLoading : MonoBehaviour
{



    private void Start() 
    {
       StartCoroutine(WaitForSceneLoad());
    }

    private IEnumerator WaitForSceneLoad() {
    yield return new WaitForSeconds(3);
    SceneManager.LoadScene(1);
    
}


    
}
