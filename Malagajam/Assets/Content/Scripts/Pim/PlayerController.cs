using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public bool movementEnabled = true;

    [SerializeField]
    float movementSpeed;

    [SerializeField]
    float jumpForce;

    //Groundcheck
    [SerializeField]
    LayerMask groundLayer;
    bool isGrounded = true;
    [SerializeField] private float _groundCheckRayLength = 0.52f;

    [SerializeField] private float _interactRadius = 2;
    [SerializeField] private LayerMask _interactableMask;

    private PlayerInput _playerInput;
    private Vector2 _inputVector;
    private Vector3 _newVelocity;

    private Rigidbody rb;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private float _coyoteTimeInSeconds = 0.2f;
    private float _coyoteTimer = 0f;

    [SerializeField] private AudioSource _walkAudio, _jumpAudio;
    [SerializeField] private List<AudioClip> _walkClips = new List<AudioClip>();

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
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
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
            UpdateAnimator();
            if (_inputVector.magnitude > 0 && !_walkAudio.isPlaying)
            {
                _walkAudio?.PlayOneShot(_walkClips[Random.Range(0, _walkClips.Count)]);
            }
            GroundCheck();

            if (_playerInput.PlayerMap.Jump.IsPressed() && isGrounded)
            {
                Jump();
            }

            Move();
        }

        if (_playerInput.PlayerMap.Interact.triggered)
        {
            InteractWithEnvironment();
        }

    }

    private void UpdateAnimator()
    {
        _animator.SetBool("Walking", _inputVector.magnitude > 0);
        float directionFloat = 0f;

        if (_inputVector.x != 0)
        {
            _spriteRenderer.flipX = _inputVector.x > 0;
            directionFloat = 3f;
        }

        switch (_inputVector.y)
        {
            case 1:
                directionFloat = 1f;
                break;
            case -1:
                directionFloat = 2f;
                break;
            default:
                break;
        }

        if (directionFloat != 0)
        {
            _animator.SetFloat("Direction", directionFloat);
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

        if(nearbyColliders.Length <= 0) 
        {
            return; 
        }

        closest.GetComponent<IInteractable>()?.Interact();

    }

    #region Movement Methods
    void Move()
    {
        rb.velocity = _newVelocity;
    }

    void GetInput()
    {
        _inputVector = _playerInput.PlayerMap.Movement.ReadValue<Vector2>();
        _newVelocity = new Vector3(_inputVector.x * movementSpeed, rb.velocity.y, _inputVector.y * movementSpeed);
    }

    #region jump
    void Jump()
    {
        isGrounded = false;
        _jumpAudio?.Play();
        _newVelocity.y = jumpForce;
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
            if (isGrounded && _coyoteTimer < _coyoteTimeInSeconds)
            {
                _coyoteTimer += Time.deltaTime;
            }
            else
            {
                isGrounded = false;
                _coyoteTimer = 0;
            }
        }
    }

    #endregion jump

    #endregion Movement Methods
}