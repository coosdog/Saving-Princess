using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    int maxDistance = 10;
    int maxYDistance = -556;

    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x,player.transform.position.y+1,transform.position.z);
        if(transform.position.x > maxDistance)
            transform.position = new Vector3(maxDistance,transform.position.y,transform.position.z);
        if (transform.position.x < -maxDistance)
            transform.position = new Vector3(-maxDistance, transform.position.y, transform.position.z);
        if(transform.position.y < maxYDistance)
            transform.position = new Vector3(transform.position.x,maxYDistance,transform.position.z);
    }
}
