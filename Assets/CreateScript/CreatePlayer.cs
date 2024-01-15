using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CreaeteplayerState
{
    stay,
    move,
    trap
}
public class CreatePlayer : MonoBehaviour
{
    public bool isPlay;
    [Header("Manager")]
    public GameManager gameManager;
    public AudioManager AM;

    [Header("Audio")]
    public AudioClip cancleAudio;
    public AudioClip moveAudio;

    [Header("Player")]
    public CreaeteplayerState state;
    public CreatePlayerMove pMove;

    float jumpCool = 3;
    float jumpCoolMax = 3;


    public void InputSound(AudioClip clip)
    {
        AM.mainaudio.clip = clip;
        AM.mainaudio.Play();
    }

    void Start()
    {
        state = CreaeteplayerState.stay;
        pMove = GetComponent<CreatePlayerMove>();
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
                    if (checkCol.Length > 0)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                    }
                    AudioSource.PlayClipAtPoint(cancleAudio, transform.position);
                    StopCoroutine(JumpCool());
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

        while (jumpCool > 0f)
        {
            jumpCool -= 1 * Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }

        jumpCool = jumpCoolMax;
        pMove.isJump = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z), 0.6f);
    }
}
