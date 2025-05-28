using UnityEngine;
using UnityEngine.Events;

public class InvokeOnKeyboardInput : MonoBehaviour
{
    /// <summary>
    /// Represents which input type to listen for.
    /// </summary>
    public enum Context
    {
        Press,
        Hold,
        Release
    }
    [Tooltip("What keyboard key should be used for the input")]
    public KeyCode key;
    [Tooltip("What input type this component should listen for")]
    public Context context;
    [Tooltip("What listeners to invoke when the input is ")]
    public UnityEvent action;

    void Update()
    {
        //Do something different depending on the desired context
        switch (context)
        {
            //If we're listening for a single press, check using GetKeyDown
            case Context.Press:
                if (Input.GetKeyDown(key))
                    Invoke();
                break;

            //If we're listening for a hold, check using GetKey
            case Context.Hold:
                if (Input.GetKey(key))
                    Invoke();
                break;

            //If we're listening for a release, check using GetKeyUp
            case Context.Release:
                if (Input.GetKeyUp(key))
                    Invoke();
                break;

            //If 'context' is somehow a different value from the above options, do nothing
            default:
                break;
        }
    }

    void Invoke()
    {
        //Trigger the listeners
        action.Invoke();
    }
}
