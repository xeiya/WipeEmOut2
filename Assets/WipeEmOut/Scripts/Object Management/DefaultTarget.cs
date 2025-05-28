using UnityEngine;

public class DefaultTarget : MonoBehaviour
{
    /// <summary>
    /// The transform to default to.
    /// </summary>
    public static Transform Target;

    void Awake()
    {
        //Set the default target to this object's transform
        Target = transform;
    }

    //OnDestroy runs when this component's game object is destroyed
    void OnDestroy()
    {
        //If we're the current default target...
        if (Target == transform)
        {
            //Remove ourself from the default target (we don't exist anymore!)
            Target = null;
        }
    }
}
