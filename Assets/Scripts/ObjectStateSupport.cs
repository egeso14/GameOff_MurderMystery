using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;

public class ObjectStateSupport : ICallbackServiceProvider
{
    
    public void PrepareStateChangeCallbacks(ObjectState state, InteractableObject obj)
    {
        if (state == null)
        {
            Debug.Log(obj.ToString() + " hasn't been assigned a state");
            return;
        }

        // find all entities that implement ICallbackServiceProvider
        ICallbackServiceProvider[] listOfProviders = FindCallbackServiceProviders();

        // create and fill the list of callbacks 
        CallbackContainer callbackContainer = new CallbackContainer();
        for (int i = 0; i < listOfProviders.Length; i++)
        {
            listOfProviders[i].ProvideCallbacks(state, obj, callbackContainer);
        }

        // pass the list of callbacks to the interaction factory


    }

    public static ICallbackServiceProvider[] FindCallbackServiceProviders()
    {
        List<ICallbackServiceProvider> providers = new List<ICallbackServiceProvider>();
        foreach (var provider in FindObjectsByType<ICallbackServiceProvider>(FindObjectsSortMode.None))
        {
            providers.Add(provider);
        }
        return providers.ToArray();
    }


    // the callback service of ObjectStateSupport is to provide state change callbacks
    // both for the current object and states forced by it


    // ObjectStateSupport provides:
    //                   - OneShot Callbacks
    private void AddOneShotCallbacks(ObjectState state, InteractableObject obj, CallbackContainer container)
    {
        // we want to do add two types of OneShotCallbacks:
        // 1. for this object's next state change

        ObjectState nextState = ObjectStateDB.GetObjectState(state.objectID, state.nextState);
        UnityAction UA_prepareStateChangeCallbacks  = () => PrepareStateChangeCallbacks(nextState, obj);

        // 2. for any forced objects' state change

        Dictionary<ObjectID, int> forcedStates = state.otherObjectStatesForced;

        foreach (ObjectID other in forcedStates.Keys)
        {
            GameObject otherObject = 
        }
    }





}
