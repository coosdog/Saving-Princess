using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Player player;
    Collider colldier;
    Animator animator;
    Rigidbody rb;

    int power = 10;
    int maxYVelocity = -10;
    int maxXVelocity = 30;

    float gravityPower = 5;
    float jumpPower = 25;
    float maxRay = 1;


    [SerializeField]
    bool isGround;
    public bool isJump = true;

    RaycastHit hit;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
        colldier = GetComponent<Collider>();
        animator = GetComponent<Animator>();
    }

    public void TriggerMove()
    {
        colldier.isTrigger = true;
    }
    void ResetVelocity()
    {
        rb.velocity = new Vector3(0, 0, 0);
    }
    public void Jump()
    {
        animator.SetTrigger("Jump");
        ResetVelocity();
        rb.AddForce(Vector3.up * jumpPower * Time.deltaTime, ForceMode.Impulse);
    }
    void Update()
    {
        animator.SetBool("IsLWalk", false);
        animator.SetBool("IsRWalk", false);
        if (player.isPlay)
        {
            if (rb.velocity.x > 0)
            {
                if (rb.velocity.x > maxXVelocity)
                    rb.velocity = new Vector3(maxXVelocity, rb.velocity.y, rb.velocity.z);
                Debug.DrawRay(transform.position, Vector3.right * maxRay, Color.yellow);
                if (Physics.Raycast(transform.position, Vector3.right, out hit, maxRay))
                    if (hit.collider.gameObject.tag == "Wall")
                    {
                        /*
                        Collider[] checkCol = Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z), 0.5f, 1 << 6);
                        if (checkCol.Length > 0)
                        {
                            transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                        }
                        */
                        colldier.isTrigger = false;
                    }
            }
            else if (rb.velocity.x < 0)
            {
                if (rb.velocity.x < -maxXVelocity)
                    rb.velocity = new Vector3(-maxXVelocity, rb.velocity.y, rb.velocity.z);
                Debug.DrawRay(transform.position, Vector3.left * maxRay, Color.yellow);
                
                if (Physics.Raycast(transform.position, Vector3.left, out hit, maxRay))
                    if (hit.collider.gameObject.tag == "Wall")
                    {
                        /*
                        Collider[] checkCol = Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z), 0.5f, 1 << 6);
                        if (checkCol.Length > 0)
                        {
                            transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                        }
                        */
                        colldier.isTrigger = false;
                    }
                
            }

            if (rb.velocity.y < 0)
            {
                rb.AddForce(0, -gravityPower, 0);
                if (rb.velocity.y < maxYVelocity)
                {
                    rb.velocity = new Vector3(rb.velocity.x, maxYVelocity, rb.velocity.z);
                }
                if (colldier.isTrigger)
                    colldier.isTrigger = false;
            }

            if (player.state != playerState.trap)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    player.state = playerState.move;
                    animator.SetBool("IsLWalk", true);
                    rb.velocity = new Vector3(-power, rb.velocity.y, 0);
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    player.state = playerState.move;
                    animator.SetBool("IsRWalk", true);
                    rb.velocity = new Vector3(power, rb.velocity.y, 0);
                }
                else
                    player.state = playerState.stay;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("충돌");
        if (collision.gameObject.tag == "Ground")
        {
            rb.drag = 10;
            isGround = true;
            player.state = playerState.stay;
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log("충돌 해제");
        if (collision.gameObject.tag == "Ground")
        {
            rb.drag = 0;
            isGround = false;
        }
    }

}
