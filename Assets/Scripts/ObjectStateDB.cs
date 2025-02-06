using UnityEngine;


public enum ObjectID
{
    
    
}

[CreateAssetMenu(fileName = "ObjectStateDB", menuName = "Scriptable Objects/ObjectStateDB")]

public class ObjectStateDB : ScriptableObject
{
    public static ObjectState GetObjectState(ObjectID id, int stateIndex)
    {
        Debug.Log("ObjectStateDb.GetObjectState() is not yet iimplemented");
        return null;
    }
}
