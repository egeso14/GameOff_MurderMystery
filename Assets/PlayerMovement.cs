using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 xyDir;
    private bool _moving;
    
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
            Vector2 currentPos = _playerRigidBody.position;
            _playerRigidBody.MovePosition(currentPos + xyDir * 0.2f);
        }
    }




}
