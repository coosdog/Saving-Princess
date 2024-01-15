using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject mine;
    public AudioClip explosionAC;
    int ExplosionLimit = 3;
    int minePower = 20;
    Vector3 dir = Vector3.zero;
    private void Start()
    {
    }
    public void TrapExplosion()
    {
       Trap trap = GetComponent<Trap>();
        Collider[] cols;
        cols = Physics.OverlapSphere(transform.position, ExplosionLimit, 1 << 7);
        if (cols.Length > 0)
        {
            if (cols[0].GetComponent<Player>() != null) 
            {
            cols[0].GetComponent<Player>().InputSound(explosionAC);
            }
            else if (cols[0].GetComponent<CreatePlayer>() != null) 
            {
                cols[0].GetComponent<CreatePlayer>().InputSound(explosionAC);
            }
            dir = cols[0].transform.position - mine.transform.position;
            cols[0].gameObject.GetComponent<Rigidbody>().AddForce(dir*minePower,ForceMode.Impulse);
        }
        //exaudio.clip = originAC;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, ExplosionLimit); // trap문서 안의 exittrap의 limit
    }
}
