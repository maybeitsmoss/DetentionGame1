using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{

    /*private CharacterController _characterController;

    public float MovementSpeed = 10f, RotationSpeed = 5f;

    private float _rotationY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void Move(Vector2 movementVector)
    {
        Vector3 move = transform.forward * movementVector.y + transform.right * movementVector.x;
        move = move * MovementSpeed * Time.deltaTime;
        _characterController.Move(move);
    }

    public void Rotate(Vector2 rotationVector)
    {
        _rotationY += rotationVector.x * RotationSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0, _rotationY, 0);
    }*/

    private InputAction _moveAction, _lookAction;

    public float moveSpeed = 10f;

    private CharacterController controller;
    public CameraController cameraController;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _lookAction = InputSystem.actions.FindAction("Look");
    }

    private void Update()
    {
        Vector2 movementVector = _moveAction.ReadValue<Vector2>();
        Move(movementVector);

        //Vector2 lookVector = _lookAction.ReadValue<Vector2>();

    }

    private void Move(Vector2 movementVector)
    {
        Vector3 move = transform.forward * movementVector.y + transform.right * movementVector.x;
        move = move * moveSpeed * Time.deltaTime;
        controller.Move(move);
    }
}
