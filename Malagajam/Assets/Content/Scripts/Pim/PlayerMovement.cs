using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float movementSpeed;

    [SerializeField]
    float jumpForce;
    bool readyToJump;

    //Groundcheck
    [SerializeField]
    LayerMask groundLayer;
    bool isGrounded;



    private Vector3 direction;

    private Rigidbody rb;
    private float multiplier = 20;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        readyToJump = true;
    }

    private void Update()
    {
        GetInput();

        if (Input.GetButton("Jump")&& isGrounded && readyToJump)
        {
            Jump();
        }

    }
    private void FixedUpdate()
    {
        Move();
        GroundCheck();

    }

    #region Movement Methods
    void Move()
    {
        transform.Translate(direction * movementSpeed / multiplier);
        //transform.Translate(transform.right * PlayerDirX * speed * Time.deltaTime);
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
        Invoke("ReadyToJump", 0.5f);
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