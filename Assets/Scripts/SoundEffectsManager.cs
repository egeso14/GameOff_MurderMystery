using UnityEngine;
using UnityEngine.Events;

public enum ESoundEffect
{

}
public class SoundEffectsManager : MonoBehaviour
{
    SoundEffectsManager instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public UnityAction ProvideCallback(GameObject interactable, ObjectState state)
    {
        UnityAction callback = () => Debug.Log("This is the object state" + state);
        return callback;
    }

}
