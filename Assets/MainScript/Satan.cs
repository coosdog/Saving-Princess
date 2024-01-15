using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Satan : MonoBehaviour
{
    public GameManager gm;
    public MonManager mon;
    public EventText satanET;
    public bool Die = false;
    public Sprite DieSprite;
    Animator animator;
    int life = 3;

    public int Life
    { get { return life; }
        set 
        {
        life = value;
            if(life <=0)
            {
                animator.SetTrigger("Die");
                gm.BossExit();
                mon.Cancel();
                return;
            }
            animator.SetTrigger("Damege");
        }
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        satanET = GetComponent<EventText>();
    }

    public void ChangeID()
    {
        satanET.ID = 4;
        satanET.talkIndex = 0;
        satanET.isSatan = false;
        satanET.SelfImege = DieSprite;
        //UpdateText();
        
    }
}
