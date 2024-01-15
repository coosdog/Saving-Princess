using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Prefab;
    public GameObject ShootTransform;
    float makingTime = 2.5f;
    float limitTime = 1f;
    public float MakingTime
    {
        get { return makingTime; }
        set
        {
            makingTime = value;
            if (makingTime <= limitTime)
                makingTime = limitTime;
        }
    }
    void MakeBullet()
    {
        Instantiate(Prefab,ShootTransform.transform.position, transform.rotation);
    }
    public void ShootBluuet()
    {
        CancelInvoke("MakeBullet");
        InvokeRepeating("MakeBullet", 1f, MakingTime);
    }
    void Start()
    {
        InvokeRepeating("MakeBullet", 1f, MakingTime);
    }

}
