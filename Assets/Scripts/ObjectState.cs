using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectState", menuName = "Scriptable Objects/ObjectState")]
public class ObjectState : ScriptableObject
{
    // Location
    [SerializeField] public readonly bool ObjectDisplaced;
    [SerializeField] public readonly EDisplacementType displacementType;
    [SerializeField] public readonly float newLocation;

    // Mouse
    [SerializeField] public readonly EMouseIcons mouseOnHover;
    [SerializeField] public readonly EMouseEffects mouseEffectOnClick;

    // Sound effects
    [SerializeField] public readonly ESoundEffect soundEffectOnClick;
    [SerializeField] public readonly ESoundEffect[] soundEffectsOnDialog;
    [SerializeField] public readonly EBackgroundMusic newBackgroundMusic;

    // State
    [SerializeField] public readonly int nextState;
    [SerializeField] public readonly Dictionary<ObjectID, int> otherObjectStatesForced;

    // Dialog
    [SerializeField] public readonly string[] dialogLines;

    // Constant fields
    [SerializeField] public readonly string objectDescription;
    [SerializeField] public readonly ObjectID objectID;
}