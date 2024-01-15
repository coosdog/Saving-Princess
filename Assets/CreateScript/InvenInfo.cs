using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InvenInfo : MonoBehaviour, IPointerClickHandler
{
    public int infoID;
    public Sprite sprite;
    public CreatInfo[] creatinfos = new CreatInfo[9];
    Image image;
    public void OnPointerClick(PointerEventData eventData)
    {
        for(int i = 0; i < creatinfos.Length; i++)
        {
            creatinfos[i].IDNum = infoID;
            creatinfos[i].ChangImage();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = sprite;
    }

}
