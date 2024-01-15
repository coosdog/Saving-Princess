using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    bool isStart = false;
    int i = 1;
    public Image[] CutImage;
    public TextMeshProUGUI PressSpace;
    public Image TitleImage;
    public AudioSource AL;
    bool isListen = true;

    public void ChangeScene()
    {
        isStart = true;
    }
    public void CreateMode()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void Mute()
    {
        isListen = !isListen;
        if (isListen)
        {
            AL.volume = 1.0f;
        }
        if (!isListen)
        {
            AL.volume = 0f;
        }
    }

    void Start()
    {
        TitleImage.gameObject.SetActive(true);
        for (int i = 0; i < CutImage.Length; i++)
        {
            CutImage[i].gameObject.SetActive(false);
        }
        PressSpace.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isStart)
        {
            TitleImage.gameObject.SetActive(false);
            PressSpace.gameObject.SetActive(true);
            CutImage[0].gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (i < CutImage.Length)
                {
                    CutImage[i].gameObject.SetActive(true);
                    i++;
                }
                else
                {
                    SceneManager.LoadScene("MainScene");
                }
            }

        }
    }
}
