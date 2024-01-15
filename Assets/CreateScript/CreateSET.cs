using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateSET : MonoBehaviour
{
    public Image set;
    bool isSet = false;

    void ToggleSet()
    {
        isSet = !isSet;
        if (isSet)
            set.gameObject.SetActive(true);
        else if(!isSet)
            set.gameObject.SetActive(false);
    }
    void Start()
    {
        set.gameObject.SetActive(false);
    }

    public void SetOpen()
    {
        ToggleSet();
    }

    public void NoCreatre()
    {
        set.gameObject.SetActive(false);
    }

    public void YesCreate()
    {
        SceneManager.LoadScene("StartScene");
    }

}
