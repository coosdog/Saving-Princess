using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChooseLR
{
    Left = 1 << 0,
    Right = 1 << 1
}

public class GroundLRMove : MonoBehaviour
{
    Vector3 origin;
    Vector3 targetPlace;
    Vector3 dir;
    public ChooseLR chooseLR;

    bool isMove = false;
    bool isTurnPoint = false;
    bool isLRcheck(ChooseLR choose)
    {
        return (chooseLR & choose) != 0;
    }
    private void Start()
    {
        origin = transform.position;
        if(isLRcheck(ChooseLR.Left) )
        {
            targetPlace = new Vector3(transform.position.x -10,transform.position.y,transform.position.z);
            dir = targetPlace - origin;
            isMove = true;
        }
        if (isLRcheck(ChooseLR.Right))
        {
            targetPlace = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z);
            dir = targetPlace - origin;
            isMove =true;
        }
    }

    void Update()
    {
        if(isMove && !isTurnPoint) 
        {
            transform.position += dir * Time.deltaTime;
            if(transform.position.x > targetPlace.x-1 && transform.position.x < targetPlace.x +1 )
                isTurnPoint = true;
        }
        else
        {
            transform.position -= dir * Time.deltaTime;
            if(transform.position.x > origin.x -1 && transform .position.x < origin.x +1)
               isTurnPoint = false;
        }
    }
}
