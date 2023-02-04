using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
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
    [SerializeField] private float _groundCheckRayLength = 0.52f;

    [SerializeField] private float _interactRadius = 2;
    [SerializeField] private LayerMask _interactableMask;

    private PlayerInput _playerInput;

    private Vector3 direction;

    private Rigidbody rb;
    private float multiplier = 20;

    private void OnEnable()
    {
        _playerInput.PlayerMap.Enable();
    }

    private void OnDisable()
    {
        _playerInput.PlayerMap.Disable();
    }

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!movementEnabled)
        {
            rb.velocity = Vector3.zero;
        }

        if (movementEnabled)
        {
            GetInput();
            GroundCheck();

            if (_playerInput.PlayerMap.Jump.ReadValue<float>() == 1 && isGrounded)
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
        }
    }

    private void InteractWithEnvironment()
    {
        Collider[] nearbyColliders = Physics.OverlapSphere(transform.position, _interactRadius, _interactableMask);
        Collider closest = new Collider();
        float distance = 200f;
        foreach (Collider collider in nearbyColliders)
        {
            float distanceToCollider = Vector3.Distance(transform.position, collider.transform.position);
            if (distanceToCollider < distance)
            {
                closest= collider;
                distance = distanceToCollider;
            }
        }

        closest.GetComponent<IInteractable>().Interact();
    }

    #region Movement Methods
    void Move()
    {
        rb.AddForce(direction * movementSpeed *Time.deltaTime * multiplier);
    }

    void GetInput()
    {
        Vector2 input = _playerInput.PlayerMap.Movement.ReadValue<Vector2>();
        direction = new Vector3(input.x, 0, input.y);
    }



    #region jump
    void Jump()
    {
        readyToJump = false;
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(Vector3.up * jumpForce);
        Invoke("ReadyToJump", 0.05f);
    }
    void ReadyToJump()
    {
        readyToJump= true;
    }

    void GroundCheck()
    {
        Debug.DrawLine(transform.position, transform.position + (-transform.up * _groundCheckRayLength), Color.green);
        if (Physics.Raycast(transform.position, -transform.up, _groundCheckRayLength, groundLayer))
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