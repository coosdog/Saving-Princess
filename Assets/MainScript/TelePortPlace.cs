using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelePortPlace : MonoBehaviour
{
    public GameObject Teleport;
    
    public void TargetMove(Player Movetarget)
    {
        Debug.Log("¿€µø");
        Movetarget.transform.position = Teleport.transform.position;
    }
    public void TargetMove(CreatePlayer Movetarget)
    {
        Movetarget.transform.position = Teleport.transform.position;
    }
}
