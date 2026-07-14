using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField] private Transform _cameraTransform;

    [SerializeField] private float _walkSpeed = 12f;
    [SerializeField] private float _gravity = -9.81f * 2f;
    [SerializeField] private float _jumpForce = 2f;

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundDistance = 0.4f;
    [SerializeField] private LayerMask _groundMask;

    [SerializeField] private Vector3 _velocity;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
    }

    private void HandleMovement()
    {
        // Collect input from the player 
        float xInput = Input.GetAxis("Horizontal"); //Left & Right
        float zInput = Input.GetAxis("Vertical"); // Forward and Back

        // Get the Camera's forward and right vectors
        Vector3 camForward = _cameraTransform.forward;
        Vector3 camRight = _cameraTransform.right;

        // Project forward and right vectors onto the horizontal plane
        camForward.y = 0f;
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        // Calculate the movement direction relative to the camera's direction
        Vector3 moveDirection = camRight * xInput + camForward * zInput;

        // Apply the movement vector to the player
        _controller.Move(moveDirection * _walkSpeed * Time.deltaTime);
    }

    private void HandleJump()
    {
        // Reset Vertical velocity when grounded
        if (IsGrounded() && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        // Check for jump input
        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            // Reassign the velocty variable
            _velocity.y = Mathf.Sqrt(_jumpForce * -2f * _gravity);
        }

        // Apply vertical velocity to player
        _controller.Move(_velocity * Time.deltaTime);

        // Apply gravity to the player
        _velocity.y += _gravity * Time.deltaTime;
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);
    }
}