using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;
using static UnityEngine.UI.Image;

public class CoolTime : MonoBehaviour
{
    Trap trap;
    int limit = 5;
    public bool isCoolReady = false;
    bool isExit = false;
    bool isReduce = false;
    bool isMine = false;
    Vector3 origin = new Vector3(4, 1, 1);

    private void Start()
    {
        trap = GetComponent<Trap>();
        if (trap.type == Trap_Type.Exit)
            isExit = true;
        if (trap.type == Trap_Type.Reduce)
            isReduce = true;
        if (trap.type == Trap_Type.Mine)
            isMine = true;
    }

    public void CoolStart()
    {
        if (!isCoolReady)
            StartCoroutine(coolTime());
    }
    public void CoolStop()
    {
        if (isCoolReady)
        {
            StopCoroutine(coolTime());
            isCoolReady = false;
        }
    }
    IEnumerator coolTime()
    {
        if (isExit)
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, limit, 1 << 6);
            foreach (Collider col in cols)
            {
                col.gameObject.SetActive(false);
            }
            yield return new WaitForSecondsRealtime(3f);
            foreach (Collider col2 in cols)
            {
                col2.gameObject.SetActive(true);
            }
            isCoolReady = true;
        }
        else if(isReduce)
        {
            //Vector3 origin = transform.localScale;
            transform.localScale = Vector3.one;
            yield return new WaitForSecondsRealtime(3f);
            transform.localScale = origin;
        }
        else if(isMine)
        {
            Explosion explosion;
            explosion = GetComponent<Explosion>();
            yield return new WaitForSecondsRealtime(0.5f);
            explosion.TrapExplosion();
        }
        else
            yield return new WaitForSecondsRealtime(3f);
    }
}
