using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundUpDown : MonoBehaviour
{
    Vector3 GroundPlace;
    Vector3 dir;

    bool isUp = true;

    int maxY = 10;
    
    int moveSpeed = 5;
    private void Start()
    {
        int ranY = Random.Range(7, 14);
        //Debug.Log(ranY);
        GroundPlace = transform.position;
        dir = new Vector3(GroundPlace.x, GroundPlace.y + ranY, GroundPlace.z);
    }
    void Update()
    {
        if (isUp == true)
        {
            if (transform.position.y >= dir.y)
                isUp = false;
            transform.position += new Vector3(0, moveSpeed, 0) * Time.deltaTime;
        }
        else if (isUp == false)
        {
            if(transform.position.y < GroundPlace.y)
                isUp=true;
            transform.position -= new Vector3(0, moveSpeed, 0) * Time.deltaTime;
        }
    }


}
