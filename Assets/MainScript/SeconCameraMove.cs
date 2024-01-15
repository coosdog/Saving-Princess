using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeconCameraMove : MonoBehaviour
{

    public Player player;

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1, transform.position.z);
    }
}
