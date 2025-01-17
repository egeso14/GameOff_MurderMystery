using System;using System.Collections.Generic;using System.Transactions;
using UnityEngine;

public enum InteractionInput
{
    MouseHover,
    ObjectClick,
    DialogueClick,
};

public enum InteractionResponse
{
    PlayerInteractionCategory,
    DialogueActivate, // 
    DialogueNext, // has no response
    DialogueChoose, // has no response
    GameStateChange, // has no response
    SoundEffectTrigger, // has no response
    NoResponse
};



public enum PlayerInteractionCategory
{
    Inspect,
    Chat,
    PickUp,
    Place,
    Report,
    None

};

public class InteractionManager
{

    public void Interact(GameObject obj, InteractionInput input, InteractionResponse output,
                        ref PlayerInteractionCategory field)
    {
        Interactable interactableComponent = obj.GetComponent<Interactable>();
        if (interactableComponent == null)
        {
            Debug.Log("object is not interactable");
            return;
        }

        InteractionResponse response = interactableComponent.Response(input);
        if (response != output)
        {
            Debug.Log("object does not have a suitable response");
            return;
        }

        field = interactableComponent.Respond(input, this);
    }
}
