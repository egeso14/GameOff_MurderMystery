using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.PlayerLoop;
using Math = Unity.Mathematics.Geometry.Math;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 xyDir;
    private bool _moving;
    private float _moveDistance;
    
    private bool _lampOut;
    

    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private SpriteRenderer _playerSprite;
    [SerializeField] private Rigidbody2D _playerRigidBody;
    private InputAction movementXAction;
    private InputAction movementYAction;
    private InputAction flashlightAction;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        movementXAction = InputSystem.actions.FindAction("MovementX");
        movementYAction = InputSystem.actions.FindAction("MovementY");
        flashlightAction = InputSystem.actions.FindAction("Lamp");
        
        //flashlightAction = InputSystem.actions.FindAction("")
        if (movementXAction == null || movementYAction == null)
        {
            Debug.Log("could not find movement action");
        }
        else
        {
            movementXAction.performed += context => UpdateMovementState(context);
            movementYAction.performed += context => UpdateMovementState(context);
            movementXAction.canceled += context => TerminateMovementState();
            movementYAction.canceled += context => TerminateMovementState();
            flashlightAction.performed += context => TriggerLamp();
            
        }
    }

    

    // Update is called once per frame
    void Update()
    {
       Move();
    }

    private void UpdateAnimState()
    {
        _playerAnimator.SetBool("LampOut", _lampOut); //convert these to enums later
        _playerAnimator.SetFloat("AnimFaceX", xyDir.x);
        _playerAnimator.SetFloat("AnimFaceY", xyDir.y);
        _playerAnimator.SetBool("Moving", _moving);
    }

    private void UpdateMovementState(InputAction.CallbackContext input)
    {
        KeyControl axes = (KeyControl)input.control;
        Debug.Log(axes);
        
        switch (axes.keyCode)
        {
            case Key.W:
                Debug.Log("read w");
                xyDir = new Vector2(0, 1);
                _playerSprite.flipX = false;
                break;
            case Key.S:
                Debug.Log("read s");
                xyDir = new Vector2(0, -1);
                _playerSprite.flipX = false;
                break;
            case Key.A:
                xyDir = new Vector2(-1, 0);
                _playerSprite.flipX = false;
                Debug.Log("read a");
                break;
            case Key.D:
                xyDir = new Vector2(1, 0);
                _playerSprite.flipX = true;
                Debug.Log("read d");
                break;
        }
        _moving = true;
        
        UpdateAnimState();
        
    }

    private void TerminateMovementState()
    {
        if (!movementXAction.inProgress && !movementYAction.inProgress)
        {
            _moving = false;
            _moveDistance = 0;
            Debug.Log("movement action canceled");
            UpdateAnimState();
        }
        movementXAction.Disable();
        movementXAction.Enable();
        movementYAction.Disable();
        movementYAction.Enable();
        
    }

    private void Move()
    {
        if (_moving)
        {
            _moveDistance = math.lerp(_moveDistance, 0.2f, 0.1f);
            Vector2 currentPos = _playerRigidBody.position;
            _playerRigidBody.MovePosition(currentPos + xyDir * _moveDistance);
        }
    }

    private void TriggerLamp()
    {
        _lampOut = !_lampOut;
        UpdateAnimState();
    }




}
