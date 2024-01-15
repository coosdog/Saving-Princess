using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BG_TYPE
{
    Mountain = 1<<0,
    Field = 1<<1,
    UnderGround = 1<<2,
    Lava = 1<<3,
    SatanHome = 1<<4
}

public class BGCheck : MonoBehaviour
{
    public BG_TYPE BG_type;
    bool isBGCheck(BG_TYPE type)
    {
        return (BG_type & type) != 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        BackGroundManager BGM = other.GetComponent<BackGroundManager>();
        if(BGM != null) 
        {
            BGM.bgCheck = this.GetComponent<BGCheck>();
            BGM.ToggleGround();
        }
    }

}
