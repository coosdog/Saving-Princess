using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreatInven : MonoBehaviour, IPointerClickHandler
{
    public Image inven;
    bool isInven = false;

    void ToggleInven()
    {
        isInven = !isInven;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ToggleInven();
        if(isInven) 
        {
            inven.gameObject.SetActive(true);
        }
        else if(!isInven) 
        {
            inven.gameObject.SetActive(false);
        }
    }


    void Start()
    {
        inven.gameObject.SetActive(false);
    }

}
