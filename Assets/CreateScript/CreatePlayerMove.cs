using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayerMove : MonoBehaviour
{
    CreatePlayer player;
    Collider colldier;
    Animator animator;
    Rigidbody rb;

    int power = 10;
    int maxYVelocity = -15;
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
        player = GetComponent<CreatePlayer>();
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

            if (player.state != CreaeteplayerState.trap)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    player.state = CreaeteplayerState.move;
                    animator.SetBool("IsLWalk", true);
                    rb.velocity = new Vector3(-power, rb.velocity.y, 0);
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    player.state = CreaeteplayerState.move;
                    animator.SetBool("IsRWalk", true);
                    rb.velocity = new Vector3(power, rb.velocity.y, 0);
                }
                else
                    player.state = CreaeteplayerState.stay;
            }
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            rb.drag = 10;
            isGround = true;
            player.state = CreaeteplayerState.stay;
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            rb.drag = 0;
            isGround = false;
        }
    }
}
