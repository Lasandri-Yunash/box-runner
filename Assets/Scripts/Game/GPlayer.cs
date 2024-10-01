using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPlayer : MonoBehaviour
{
    public float jumpSpeed;
    private Rigidbody2D rb;

    public Transform GroundCheck;
    public float CheckRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;

    //Exra jump

    public int maxJumpValue;
    int maxJump;


    private void Start()
    {
        maxJump = maxJumpValue;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, whatIsGround);
        if (Input.GetMouseButtonDown(0) && maxJump > 0)
        {
            maxJump--;
            Jump();
        }
        else if (Input.GetMouseButtonDown(0) && maxJump == 0 && isGrounded)
        {
            Jump();
        }
        if (isGrounded)
        {
            maxJump = maxJumpValue;
        }
    }

    void Jump()
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(new Vector3(0, jumpSpeed));
    }
}
