using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public bool movementEnabled = true;

    [SerializeField]
    float movementSpeed;

    [SerializeField]
    float jumpForce;
    bool readyToJump = true;

    //Groundcheck
    [SerializeField]
    LayerMask groundLayer;
    bool isGrounded = true;



    private Vector3 direction;

    private Rigidbody rb;
    private float multiplier = 20;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!movementEnabled)
        {
            Debug.Log(rb.velocity.sqrMagnitude);
            rb.velocity = Vector3.zero;
        }
        if (movementEnabled)
        {
            GetInput();

            if (Input.GetButton("Jump") && isGrounded && readyToJump)
            {
                Jump();
            }
        }
    }
    private void FixedUpdate()
    {
        if (movementEnabled)
        {
            Move();
            GroundCheck();
        }

    }

    #region Movement Methods
    void Move()
    {
        rb.AddForce(direction * movementSpeed *Time.deltaTime * multiplier);
    }
    void GetInput()
    {
        direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
    }



    #region jump
    void Jump()
    {
        readyToJump = false;
        rb.AddForce(direction.x, jumpForce * multiplier, direction.z);
        Invoke("ReadyToJump", 0.05f);
    }
    void ReadyToJump()
    {
        readyToJump= true;
    }

    void GroundCheck()
    {
        Debug.DrawRay(transform.position, -transform.up, Color.green);
        if (Physics.Raycast(transform.position, -transform.up, 0.5f, groundLayer))
        {
            isGrounded = true;
        }
        else 
        {
            isGrounded = false;
        }
    }

    #endregion jump

    #endregion Movement Methods
}