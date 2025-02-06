using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
public class DetectiveMovement : MonoBehaviour
{
    // External refs
    DetectiveAnimations d_animations;
    SpriteRenderer d_renderer;

    // Input
    private InputAction wPressAction;
    private InputAction aPressAction;
    private InputAction sPressAction;
    private InputAction dPressAction;
    private InputStack<Vector2> inputStack;

    // Movement
    private float speedConstant;
    private Vector2 lastMove;
    public Vector2 LastMove { get { return lastMove; }
        private set
        {
            if (lastMove != value)
            {
               
                lastMove = value;
                AnimationCallback(value);
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        // W Key
        wPressAction = new InputAction("wPress", InputActionType.Button);
        wPressAction.AddBinding("<Keyboard>/w");
        wPressAction.performed += OnWPressed;
        wPressAction.canceled += OnWReleased;

        // A Key
        aPressAction = new InputAction("aPress", InputActionType.Button);
        aPressAction.AddBinding("<Keyboard>/a");
        aPressAction.performed += OnAPressed;
        aPressAction.canceled += OnAReleased;

        // S Key
        sPressAction = new InputAction("sPress", InputActionType.Button);
        sPressAction.AddBinding("<Keyboard>/s");
        sPressAction.performed += OnSPressed;
        sPressAction.canceled += OnSReleased;

        // D Key
        dPressAction = new InputAction("dPress", InputActionType.Button);
        dPressAction.AddBinding("<Keyboard>/d");
        dPressAction.performed += OnDPressed;
        dPressAction.canceled += OnDReleased;
    }

    private void Start()
    {
        d_animations = GetComponent<DetectiveAnimations>();
        d_renderer = GetComponent<SpriteRenderer>();

        inputStack = new InputStack<Vector2>();
        inputStack.Push(Vector2.zero);
        speedConstant = 6;
    }

    private void OnEnable()
    {
        // Enable all actions
        wPressAction.Enable();
        aPressAction.Enable();
        sPressAction.Enable();
        dPressAction.Enable();
    }

    private void OnDisable()
    {
        // Disable all actions
        wPressAction.Disable();
        aPressAction.Disable();
        sPressAction.Disable();
        dPressAction.Disable();
    }

    private void OnDestroy()
    {
        // Dispose of all actions
        wPressAction.Dispose();
        aPressAction.Dispose();
        sPressAction.Dispose();
        dPressAction.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        Move(Time.fixedDeltaTime);
        AdjustRotation();
    }

    private void Move(float delta)
    {
        Vector2 dir = inputStack.Peek();
        LastMove = dir;
        transform.Translate(dir * delta * speedConstant);
    }

    #region Input Callbacks
    private void OnWPressed(InputAction.CallbackContext context)
    {
        inputStack.Push(new Vector2(0, 1));
    }

    private void OnWReleased(InputAction.CallbackContext context)
    {
        inputStack.Remove(new Vector2(0, 1));
    }

    private void OnAPressed(InputAction.CallbackContext context)
    {
        inputStack.Push(new Vector2(-1, 0));
    }

    private void OnAReleased(InputAction.CallbackContext context)
    {
        inputStack.Remove(new Vector2(-1, 0));
    }

    private void OnSPressed(InputAction.CallbackContext context)
    {
        inputStack.Push(new Vector2(0, -1));
    }

    private void OnSReleased(InputAction.CallbackContext context)
    {
        inputStack.Remove(new Vector2(0, -1));
    }

    private void OnDPressed(InputAction.CallbackContext context)
    {
        inputStack.Push(new Vector2(1, 0));
    }

    private void OnDReleased(InputAction.CallbackContext context)
    {
        inputStack.Remove(new Vector2(1, 0));
    }

    #endregion

    private void AnimationCallback(Vector2 movementInput)
    {
        d_animations.UpdateMovementAnimationState(movementInput);
    }

    public void AdjustRotation()
    {
        if (lastMove.x == 1)
        {
            d_renderer.flipX = true;
        }
        else
        {
            d_renderer.flipX = false;
        }
    }

}