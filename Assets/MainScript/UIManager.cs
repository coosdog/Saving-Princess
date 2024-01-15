using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using Unity.VisualScripting;
//using UnityEditor.Build.Content;
//using UnityEditor.TextCore.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Manager")]
    public GameManager gameManager;
    public BackGroundManager BGM;
    [Header("Image")]
    public Image cencleCool;
    public Image cencleMove;
    public Image Result;
    public Image[] darkstar;
    public Image settingImage;
    [Header("TextMesh")]
    public TextMeshProUGUI time;
    public TextMeshProUGUI gold;
    public TextMeshProUGUI resultTime;
    public TextMeshProUGUI resultGold;

    public Player player;
    bool isSet = false;
    public void Setting()
    {
        isSet = !isSet;
        if (isSet)
        {
            settingImage.gameObject.SetActive(true);
        }
        else if (!isSet)
        {
            settingImage.gameObject.SetActive(false);
        }
    }

    public bool isEnding;

    float maxTime = 900;
    int min;
    int sec;
    int starCount;
    void Start()
    {
        cencleCool.gameObject.SetActive(false);
        cencleMove.gameObject.SetActive(false);
        isEnding = false;
        Result.gameObject.SetActive(false);
        settingImage.gameObject.SetActive(false);
    }

    public void ReturnScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void EndingCut()
    {
        isEnding = true;
        BGM.ChangeBGM();
        Result.gameObject.SetActive(true);
        player.isPlay = false;
        time.gameObject.SetActive(false);
        resultTime.text = time.text;
        resultGold.text = gameManager.CoinNum.ToString();
        if (maxTime >= 540)
            starCount = 3;
        else if(maxTime >= 240)
            starCount = 2;
        else if(maxTime >=0 )
            starCount = 1;
        for (int i = starCount-1; i > -1; i--) 
        {
            darkstar[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.state == playerState.trap)
            cencleMove.gameObject.SetActive(true);
        else
            cencleMove.gameObject.SetActive(false);
        maxTime -= Time.deltaTime;
        min = (int)maxTime / 60;
        sec = (int)maxTime % 60;
        if(maxTime >= 60f)
        {
            time.text = string.Format("{0:D2}:{1:D2}", min,sec);
        }
        if (maxTime < 60f)
        {
            time.text = string.Format("{0:D2}:{1:D2}", min,sec);
        }
        if (maxTime <=0f)
        {
            EndingCut();
        }
        gold.text = gameManager.CoinNum.ToString();
    }


}
