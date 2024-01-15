using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonManager : MonoBehaviour
{
    public GameObject[] createPoint = new GameObject[4];
    public GameObject[] targetPoint = new GameObject[4];
    public GameObject snowMon;
    public GameObject elkMon;
    public Satan satan;
    GameObject[] snowMan1= new GameObject[4];
    GameObject elkMon1;


    void Pick()
    {
        List<int> randomList = new List<int>() { 0, 1, 2, 3 };
        int i = 0;
        while (randomList.Count > 0)
        {
            if (i > 2)
            {
                break;
            }
            int rand = Random.Range(0, randomList.Count);
            snowMan1[randomList[rand]] = Instantiate(snowMon, createPoint[randomList[rand]].transform.position, createPoint[randomList[rand]].transform.rotation);
            snowMan1[randomList[rand]].GetComponent<BossMon>().setDir(targetPoint[randomList[rand]]);
            randomList.Remove(randomList[rand]);
            i++;
        }
        elkMon1 = Instantiate(elkMon, createPoint[randomList[0]].transform.position, createPoint[randomList[0]].transform.rotation);
        elkMon1.GetComponent<BossMon>().setDir(targetPoint[randomList[0]]);
    }

    public void Cancel()
    {
        if(snowMan1.Length >= 0)
        {
            for(int i = 0; i < snowMan1.Length; i++)
            {
               Destroy(snowMan1[i]);
            }
        }
        if(elkMon1!= null)
            Destroy(elkMon1);
        CancelInvoke();
    }

    void Start()
    {
        InvokeRepeating("Pick", 1f, 3f);
    }

    void Update()
    {
        /*
        if (satan.Life <= 0)
        {
            Debug.Log("ÀÛµ¿");
            CancelInvoke();
        }
        */
    }
}
