using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class CursorManager : MonoBehaviour
{
    public Camera mainCamera;
    private GameObject _hoverObject;
    private Texture2D _lastHoverTexture;
    [SerializeField] private Texture2D _baseHoverTexture;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        FindHoverObject();
        AskForCursorTexture();
        SetCustomCursor();
    }

    private void FindHoverObject()
    {
        if (mainCamera == null)
        {
            Debug.Log("No main camera found");
        }
        else
        {
            Vector2 worldClickPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hitCollider = Physics2D.OverlapPoint(worldClickPos);
            if (hitCollider == null)
            {
                Debug.Log("nothing to click here");
                _hoverObject = null;

            }

            _hoverObject = hitCollider.gameObject;
        }
    }

    private void AskForCursorTexture()
    {
        
    }

    private void SetCustomCursor()
    {
        Cursor.SetCursor(_lastHoverTexture, Vector2.zero, CursorMode.Auto);
    }
    
    
}
