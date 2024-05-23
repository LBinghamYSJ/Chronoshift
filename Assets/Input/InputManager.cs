using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static Vector2 Movement;

    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _runAction;
    private InputAction _jumpAction;
    private InputAction _shiftAction;
    public static bool _isRunning;
    public static bool _isJumping;
    public static bool _isShifting;
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();

        _moveAction = _playerInput.actions["Move"];
        _runAction = _playerInput.actions["Run"];
        _jumpAction = _playerInput.actions["Jump"];
        _shiftAction = _playerInput.actions["Shift"];
    }

    private void Update()
    {
        Movement = _moveAction.ReadValue<Vector2>();

        if (_runAction.WasPressedThisFrame())
        {
            _isRunning = true;
        }

        if (_runAction.WasReleasedThisFrame())
        {
            _isRunning = false;
        }

        if (_jumpAction.WasPressedThisFrame())
        {
            _isJumping = true;
        }

        if (_jumpAction.WasReleasedThisFrame())
        {
            _isJumping = false;
        }
        if (_shiftAction.WasPressedThisFrame())
        {
            _isShifting = true;
        }
        if (_shiftAction.WasReleasedThisFrame())
        {
            _isShifting = false;
        }
    }
}
