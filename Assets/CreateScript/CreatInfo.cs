using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreatInfo : MonoBehaviour, IPointerClickHandler
{
    public GameObject[] preObj = new GameObject[7];
    public Sprite[] objImage = new Sprite[7];
    public InvenInfo inven;
    public CreateManager createManager;

    int id = -1;
    public int IDNum
    {
        get { return 0; }
        set { id = value; }
    }
    Image Image;

    public void OnPointerClick(PointerEventData eventData)
    {
        //i = inven.infoID;
        if (id != -1 && preObj[id] != null && objImage[id] != null)
        {
            createManager.creatObj = preObj[id];
            
            Debug.Log(createManager.creatObj.name);
        }
        else
            return;
    }

    public void ChangImage()
    {
        Image.sprite = objImage[id];
    }

    void Start()
    {
        Image = GetComponent<Image>();
    }
}
