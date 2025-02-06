using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ICallbackServiceProvider: MonoBehaviour
{
    public virtual void ProvideCallbacks(ObjectState state, InteractableObject obj, CallbackContainer callbackContainer)
    {
        
        AddOneShotCallbacks(state, obj, callbackContainer);
        AddOnOffCallBacks(state, obj, callbackContainer);
        AddContinousCallbacks(state, obj, callbackContainer);
        return;

    }
    protected virtual void AddOneShotCallbacks(ObjectState state, InteractableObject obj, CallbackContainer container)
    {
        Debug.Log("Provider doesn't implement a ONESHOT callback");
    }
    protected virtual void AddOnOffCallBacks(ObjectState state, InteractableObject obj, CallbackContainer container)
    {
        Debug.Log("Provider doesn't implement a ONOFF callback");
    }
    protected virtual void AddContinousCallbacks(ObjectState state, InteractableObject obj, CallbackContainer container)
    {
        Debug.Log("Provider doesn't implement a CONTINOUS callback");
    }

}

public struct CallbackContainer
{
    public List<UnityAction> OneShotCallbacks;
    public List<(UnityAction, UnityAction)> OnOffCallbacks;
    public List<UnityAction> ContinousCallbacks;
    public CallbackContainer(List<UnityAction> oneShots = null, List<(UnityAction, UnityAction)> onOffs = null, List<UnityAction> continous = null)
    {
        OneShotCallbacks = oneShots == null ? new List<UnityAction>() : oneShots;
        OnOffCallbacks = onOffs == null ? new List<(UnityAction, UnityAction)>() : onOffs;
        ContinousCallbacks = continous == null ? new List<UnityAction>() : continous;
    }
    
}