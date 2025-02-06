using UnityEngine;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.Events;
using System.Collections.Generic;


public class Interaction
{
    private CancellationTokenSource cancellationTokenSource;
    private CallbackContainer callbacks;

    Interaction(CallbackContainer myCallbacks)
    {
        callbacks = myCallbacks;
    }
    

    public void TriggerOneShot()
    {
        foreach (var callback in callbacks.OneShotCallbacks)
        {
            callback.Invoke();
        }
    }
    public void TriggerOnOff(bool on)
    {
        if (on)
        {
            foreach (var callbackDuo in callbacks.OnOffCallbacks)
            {
                callbackDuo.Item1.Invoke();
            }
        }
        else
        {
            foreach (var callbackDuo in callbacks.OnOffCallbacks)
            {
                callbackDuo.Item2.Invoke();
            }
        }
    }
    public void StartContinous()
    {
        Start(callbacks.ContinousCallbacks);
    }
    public void EndContinous()
    {
        Stop();
    }

    // thread function
    private async Task RunLoop(CancellationToken token, List<UnityAction> perCycleCallbacks)
    {
        while (!token.IsCancellationRequested)
        {
            foreach(var callback in perCycleCallbacks)
            {
                callback.Invoke();
            }
            await Task.Delay((int)Time.deltaTime, token);
        }
    }

    // start a thread to run all continous callbacks
    private void Start(List<UnityAction> continousCallbacks)
    {
        if (cancellationTokenSource != null) return; // Already running
        {
            cancellationTokenSource = new CancellationTokenSource();
            Task.Run(() => RunLoop(cancellationTokenSource.Token, continousCallbacks));
        }
        
    }
    // stop all continous callbacks
    private void Stop()
    {
        cancellationTokenSource?.Cancel();
        cancellationTokenSource = null;
    }
}
