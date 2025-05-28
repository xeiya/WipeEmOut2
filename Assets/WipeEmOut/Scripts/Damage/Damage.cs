using UnityEngine;

public class Damage : MonoBehaviour
{
    /// <summary>
    /// Represents the source of the damage. Allows for a DamageReceiver to ignore a type of damage, e.g. the player can't shoot themselves 
    /// </summary>
    public enum Source
    {
        Default,
        Player,
        Enemy
    }
    [Tooltip("Where this damage is coming from")]
    public Source source;
    [Tooltip("How much damage to apply (this will be per second if on a trigger)")]
    public float amount;
}
