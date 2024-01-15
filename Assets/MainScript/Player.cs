using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public enum playerState
{
    stay,
    move,
    trap
}
public class Player : MonoBehaviour
{
    public bool isPlay;
    [Header("Manager")]
    public GameManager gameManager;
    public UIManager uiManager;
    public AudioManager AM;

    [Header("Audio")]
    public AudioClip cancleAudio;
    public AudioClip moveAudio;

    [Header("Player")]
    public playerState state;
    public PlayerMove pMove;

    [Header("others")]
    public GameObject startPoint;
    //public Satan satan;

    float jumpCool = 3;
    float jumpCoolMax = 3;


    public void InputSound(AudioClip clip)
    {
        AM.mainaudio.clip = clip;
        AM.mainaudio.Play();
    }

    void Start()
    {
        transform.position = startPoint.transform.position;
        state = playerState.stay;
        pMove = GetComponent<PlayerMove>();
        isPlay = true;
    }

    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.left * 100);
        if (isPlay)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Collider[] col = Physics.OverlapSphere(transform.position, 2, 1 << 8);
                if (col.Length > 0)
                    col[0].GetComponent<EventText>().TextAct();
                if (col.Length <= 0)
                    gameManager.textPanel.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Collider[] checkCol = Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z), 0.7f, 1 << 6);
               
                if (pMove.isJump)
                {
                    if(checkCol.Length > 0)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                    }
                    AudioSource.PlayClipAtPoint(cancleAudio, transform.position);
                    StopCoroutine(JumpCool());
                    uiManager.cencleCool.fillAmount = 1;
                    StartCoroutine(JumpCool());
                }

            }
        }
    }

    void StepSound()
    {
        AudioSource.PlayClipAtPoint(moveAudio, transform.position);
    }

    IEnumerator JumpCool()
    {

        pMove.Jump();
        pMove.isJump = false;
        uiManager.cencleCool.gameObject.SetActive(true);

        while (jumpCool > 0f)
        {
            jumpCool -= 1 * Time.deltaTime;
            uiManager.cencleCool.fillAmount = (jumpCool / jumpCoolMax);
            yield return new WaitForFixedUpdate();
        }
        uiManager.cencleCool.gameObject.SetActive(false);

        jumpCool = jumpCoolMax;
        pMove.isJump = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z), 0.6f);
    }
}
