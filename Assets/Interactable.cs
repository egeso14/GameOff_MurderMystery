using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] protected Texture2D mouseHoverTexture;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void SetMouseHoverTexture(Texture2D texture)
    {
        mouseHoverTexture = texture;
    }
    public Texture2D GetMouseHoverTexture()
    {
        return mouseHoverTexture;
    }
}
