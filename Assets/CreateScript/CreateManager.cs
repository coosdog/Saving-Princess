using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class CreateManager : MonoBehaviour
{
    public GameObject creatObj;
    Vector3 point;

    void Update()
    {
        if (creatObj != null)
        {
            //-Camera.main.transform.position.z
            point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
            if (Input.GetMouseButtonUp(1))
            {
                Instantiate(creatObj, point, creatObj.transform.rotation);
            }

        }
    }

}
