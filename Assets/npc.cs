using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class NPC : IInteractable
{
    private ObjectInteractionCategory currentInteraction;
    public Dictionary<InteractionInput, InteractionResponse> myInteractions { get; set; } //set by game state
    //[SerializeField] private Texture2D _myMouseHoverTexture;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //
        myInteractions = new Dictionary<InteractionInput, InteractionResponse>()
        {
            { InteractionInput.MouseHover, InteractionResponse.InteractionCategory}
        };
        currentInteraction = ObjectInteractionCategory.Inspect;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respond<T>(InteractionData<T> data)
    {
        switch (data.expectedResponse)
        {
            case InteractionResponse.InteractionCategory:
                data.responseData = GetObjectInteractionCategory() as T;
                
            
                
        }
    }

    public ObjectInteractionCategory GetObjectInteractionCategory()
    {
        return currentInteraction;
    }
    

    public InteractionResponse Response(InteractionInput request)
    {
        if (myInteractions.ContainsKey(request))
        {
            return myInteractions[request];
        }

        return InteractionResponse.NoResponse;
    }
}
