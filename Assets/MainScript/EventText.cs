using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventText : MonoBehaviour
{
    protected Dictionary<int, string[]> talkdata;
    public GameManager gameManager;
    public int ID;
    public int talkIndex = 0;
    public bool isSatan = false;

    public Sprite SelfImege;

    public void GenerateData()
    {
        talkdata.Add(1, new string[]
        { "정지, 여기부터는 공사구역야. 들어가면 안돼.","...","그렇구나 사탄클로스에게 잡혀간 공주를 찾으러 가는거구나.",
        "그렇다면 이것이 필요할거야. 아직 공사중인곳이라 어두울테니까.","네가 가진 금화의 갯수만큼 밝게 빛날거야." , "아참 그리고 폭탄들이 터질수도있으니 조심해.",
        "충격을 받으면 터질지도 몰라"});
        talkdata.Add(2, new string[]
        {"하하하! 공주를 되찾으러 여기까지 왔나!", "허나 모두 부질없는 짓이다! 공주는 조금있다 이곳에서 나와 결혼식을 올릴것이야!",
            "처리해 스노우맨!!!"});
        talkdata.Add(3, new string[]
        {"좋아요. 역참까지 왔으니 왕궁에서 나오는 마차를 기다리죠.", "구해줘서 고마워요."
        });
        talkdata.Add(4, new string[]
        { "사탄 클로스를 해치웠군요!", " 저 끝에 생성된 텔레포트 장치를 타고 이곳에서 빠져나가요!" });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkdata[id].Length)
            return null;
        else
            return talkdata[id][talkIndex];
    }
    private void Start()
    {
        UpdateText();
    }
    public void TextAct()
    {
        gameManager.ChangeAction(gameObject);
    }

    public void UpdateText()
    {
        talkdata = new Dictionary<int, string[]>();
        GenerateData();
    }
}
