using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;    

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public int CoinNum = 0;
    //int talkIndex = 0;

    [Header("GameObject")]
    public GameObject gameObj;
    public GameObject specialGround;
    public GameObject specialTeleport;
    public GameObject PrincessUp;
    public GameObject BossPosition;
    public Player player;
    public Satan satan;
    [Header("UI")]
    public GameObject textPanel;
    public TextMeshProUGUI talkText;
    public UIManager UIM;
    public Image image;
    [Header("Camera")]
    public Camera main;
    public Camera boss;
    
    bool[] isSpecial = new bool[2];

    public void BossMode()
    {
        boss.gameObject.SetActive(true);
        main.gameObject.SetActive(false);
        player.transform.position = BossPosition.transform.position;
    }
    public void BossExit()
    {
        main.gameObject.SetActive(true);
        boss.gameObject.SetActive(false );
        satan.Die = true;
        satan.ChangeID();
    }

    public void ChangeAction(GameObject gameObject)
    {
        textPanel.SetActive(true);
        gameObj = gameObject;
        Talk(gameObject);
    }
    void Talk(GameObject target)
    {
        EventText ET = target.GetComponent<EventText>();
        string talkData = ET.GetTalk(ET.ID, ET.talkIndex);

        image.sprite = ET.SelfImege;

        if(ET.isSatan)
        {
            specialTeleport.SetActive(true);
            PrincessUp.SetActive(true);
        }
        if (talkData == null)
        {
            if(ET.ID == 2 && ET.isSatan && satan.Die == false)
            {
                BossMode();
            }
            if(ET.ID == 3)
            {
                UIM.EndingCut();
            }
            //talkIndex = 0;
            textPanel.SetActive(false);
            isSpecial[0] = true;
            SGround();
            return;
        }

        talkText.text =talkData;
        ET.talkIndex++;
    }

    void SGround()
    {
        if (isSpecial[0])
            specialGround.transform.localScale = Vector3.one;
    }
    private void Start()
    {
        textPanel.SetActive(false);
        specialTeleport.SetActive(false);
        PrincessUp.SetActive(false);
        isSpecial[0] = false;
        isSpecial[1] = false;
    }
   
}
