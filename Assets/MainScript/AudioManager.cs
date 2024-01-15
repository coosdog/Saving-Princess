using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource mainaudio;
    public AudioSource BGM;
    
    bool isMain = true;
    bool isBGM = true;
    

    
    public void MainMute()
    {
        isMain = !isMain;
        if(isMain) 
        {
            mainaudio.volume = 1f;
        }
        else if(!isMain)
        {
        mainaudio.volume = 0;
        }
    }
    public void BGMMute()
    {
        isBGM = !isBGM;
        if (isBGM)
        {
            BGM.volume = 1f;
        }
        else if (!isBGM)
        {
            BGM.volume = 0;
        }
    }

    void Start()
    {
        mainaudio = GetComponent<AudioSource>();
        
    }

}
