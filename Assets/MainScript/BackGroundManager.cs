using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundManager : MonoBehaviour
{
    public Player player;

    [Header("Image")]
    public RawImage Mountain;
    public RawImage Field;
    public RawImage UnderGround;
    public RawImage Lava;
    public RawImage SatanHome;
    public Image[] BGtext = new Image[5];
    public Image UGSpeical;

    public GameObject SpecialBGUG;

    [Header("Audio")]
    public AudioClip[] BGM = new AudioClip[2];
    AudioSource BGaudio;
    [Header("Manager")]
    public UIManager UIM;
    public GameManager gameManager;
    public bool[] isBG = new bool[5];
    bool[] isBGT = new bool[5];

    int maxCoinnum = 10;


    public BGCheck bgCheck;
    public void ToggleGround()
    {
        switch (bgCheck.BG_type)
        {
            case BG_TYPE.Mountain:
                isBG[0] = !isBG[0];
                break;
            case BG_TYPE.Field:
                isBG[1] = !isBG[1];
                break;
            case BG_TYPE.UnderGround:
                isBG[2] = !isBG[2];
                break;
            case BG_TYPE.Lava:
                isBG[3] = !isBG[3];
                break;
            case BG_TYPE.SatanHome:
                isBG[4] = !isBG[4];
                break;
            default:
                break;
        }
    }
    public void ChangeBGM()
    {
        BGaudio.clip = BGM[1];
        BGaudio.Play();
    }

    void Start()
    {
        BGaudio = GetComponent<AudioSource>();
        for (int i = 0; i < isBG.Length; i++)
        {
            isBG[i] = true;
            isBGT[i] = true;
        }
        for (int i = 0; i < BGtext.Length; i++)
        {
            BGtext[i].gameObject.SetActive(false);
        }
        SpecialBGUG.SetActive(false);
        //UGSpeical.rectTransform.sizeDelta = new Vector2(1, 1);
    }
    void Update()
    {
        if (isBG[0] == false)
        {
            if (isBG[0] == false && player.transform.position.y > -85)
                isBG[0] = true;
            Mountain.gameObject.SetActive(false);
        }
        else if (isBG[0] == true)
        {
            if (isBG[0] == true && player.transform.position.y < -85)
                isBG[0] = false;
            Mountain.gameObject.SetActive(true);
        }
        if (isBG[1] == false)
        {
            if (isBG[1] == false && player.transform.position.y > -205)
                isBG[1] = true;
            Field.gameObject.SetActive(false);
        }
        else if (isBG[1] == true)
        {
            if (isBG[1] == true && player.transform.position.y < -205)
                isBG[1] = false;
            Field.gameObject.SetActive(true);
        }
        if (isBG[2] == false)
        {
            if (isBG[2] == false && player.transform.position.y > -325)
                isBG[2] = true;
            UnderGround.gameObject.SetActive(false);
        }
        else if (isBG[2] == true)
        {
            if (isBG[2] == true && player.transform.position.y < -325)
                isBG[2] = false;
            UnderGround.gameObject.SetActive(true);
        }
        if (isBG[3] == false)
        {
            if (isBG[3] == false && player.transform.position.y > -445)
                isBG[3] = true;
            Lava.gameObject.SetActive(false);
        }
        else if (isBG[3] == true)
        {
            if (isBG[3] == true && player.transform.position.y < -445)
                isBG[3] = false;
            Lava.gameObject.SetActive(true);
        }
        if (isBG[4] == false)
            SatanHome.gameObject.SetActive(false);
        else if (isBG[4] == true)
            SatanHome.gameObject.SetActive(true);
        if (player.transform.position.y < -203 && player.transform.position.y > -322)
        {
            if (gameManager.CoinNum > maxCoinnum)
                UGSpeical.rectTransform.sizeDelta = new Vector2(maxCoinnum, maxCoinnum);
            else
            {
                UGSpeical.rectTransform.sizeDelta = new Vector2(gameManager.CoinNum, gameManager.CoinNum);
            }
            SpecialBGUG.SetActive(true);
        }
        else SpecialBGUG.SetActive(false);

        if (player.transform.position.y > -85 && isBGT[0] == true)
        {
            StartCoroutine(BGTitle(0));
            isBGT[0] = false;
            isBGT[1] = true;
        }
        else if (player.transform.position.y < -85 && player.transform.position.y > -205 && isBGT[1] == true)
        {
            StartCoroutine(BGTitle(1));
            isBGT[0] = true;
            isBGT[1] = false;
        }
        else if (player.transform.position.y < -205 && player.transform.position.y > -325 && isBGT[2] == true)
        {
            StartCoroutine(BGTitle(2));
            isBGT[1] = true;
            isBGT[2] = false;
            isBGT[3] = true;
        }
        else if (player.transform.position.y < -325 && player.transform.position.y > -445 && isBGT[3] == true)
        {
            StartCoroutine(BGTitle(3));
            isBGT[2] = true;
            isBGT[3] = false;
            isBGT[4] = true;
        }
        else if (player.transform.position.y < -445 && isBGT[4] == true)
        {
            StartCoroutine(BGTitle(4));
            isBGT[3] = true;
            isBGT[4] = false;
        }
    }

    IEnumerator BGTitle(int num)
    {
        BGtext[num].gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(2f);
        BGtext[num].gameObject.SetActive(false);
    }


}
