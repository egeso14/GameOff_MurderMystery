using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable: MonoBehaviour
{
    public Dictionary<InteractionInput, InteractionResponse> myInteractions { get; set; }
    
    public InteractionResponse Response(InteractionInput res)
    {
        if (myInteractions.ContainsKey(res))
        {
            return myInteractions[res];
        }

        return InteractionResponse.NoResponse;
    }

    public PlayerInteractionCategory Respond(InteractionInput input, InteractionManager manager)
    {
        return PlayerInteractionCategory.None;
    }
    
    


}
