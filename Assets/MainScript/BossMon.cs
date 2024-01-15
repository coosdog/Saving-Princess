using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BossMon : MonoBehaviour
{
    public bool isElk;
    bool isSatanAttack;
    float moveSpeed = 0.5f;
    Vector3 dir;
    Vector3 dir2;
    Rigidbody rb;

    public void setDir(GameObject goal)
    {
        dir = goal.transform.position - transform.position;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if(isSatanAttack)
        {
            transform.Rotate(new Vector3(0, 0, 30));
            transform.position += new Vector3(-1,0,0)*Time.deltaTime*5;
        }
        else
        {
            transform.position += dir * Time.deltaTime * moveSpeed;

        }
        //Debug.Log(dir);
        if (transform.position.z < -50)
            Destroy(this.gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (isElk)
        {
            if (other.GetComponent<Player>() != null)
            {
                //Vector3 target = other.GetComponent<Player>().satan.transform.position;
                isSatanAttack = true;
                rb.isKinematic = false;
            }
        }
        if(other.GetComponent<Satan>() != null)
        {
            Debug.Log("ªÁ≈∫");
            other.GetComponent<Satan>().Life -= 1;
            Destroy(this.gameObject);
        }
    }


}
