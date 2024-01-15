using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveToMouse : MonoBehaviour
{
    [SerializeField]
    bool isMove = false;
    Vector2 ClickPoint;
    Vector2 dir;
    void CameraMoving()
    {
        dir = ClickPoint - (Vector2)Input.mousePosition;
        transform.position -= (Vector3)dir * Time.deltaTime * 0.03f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isMove = true;
            ClickPoint = Input.mousePosition;
            Debug.Log(ClickPoint);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
            isMove = false;
        if(isMove)
            CameraMoving();
    }
}
