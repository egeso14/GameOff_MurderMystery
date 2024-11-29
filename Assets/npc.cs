using UnityEngine;

public class NPC : Interactable
{
    //[SerializeField] private Texture2D _myMouseHoverTexture;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetMouseHoverTexture(mouseHoverTexture);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
