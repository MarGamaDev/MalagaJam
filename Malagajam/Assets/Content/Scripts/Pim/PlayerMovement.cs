using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float movementSpeed;

    [SerializeField]
    float jumpForce;


    [SerializeField]
    LayerMask groundLayer;

    private Vector3 direction;

    private Rigidbody rb;
    private float multiplier = 20;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GetInput();

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump Started");
            Jump();
        }

    }
    private void FixedUpdate()
    {
        Move();


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
        Debug.Log("Jump Started");
        rb.AddForce(direction.x, jumpForce * multiplier, direction.z);
    }

    #endregion jump

    #endregion Movement Methods
}