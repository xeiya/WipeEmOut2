using UnityEngine;
using UnityEngine.Events;

public class InvokeAfter : MonoBehaviour
{
    [Tooltip("How many seconds to wait before invoking")]
    public float seconds;
    [Tooltip("The lowest value seconds is allowed to be")]
    public float minimum = 0.5f;
    [Tooltip("Whether to automatically start again after finishing")]
    public bool looping;
    [Tooltip("Whether to automatically begin on first load")]
    public bool beginOnStart;
    [Tooltip("What to invoke after the delay")]
    public UnityEvent action;

    //The last time the delay was started
    private float timeStart;
    //Whether this delay is currently counting down 
    private bool started;

    void Start()
    {
        timeStart = Time.time;

        //Automatically start if we're supposed to
        if (beginOnStart)
        {
            Begin();
        }
    }

    void Update()
    {
        //If we're not currently running, do nothing
        if (!started)
            return;

        //If the current time is more than our delay's start time plus the delay's duration, our delay is over
        if (Time.time > timeStart + seconds)
        {
            Invoke();
        }
    }

    /// <summary>
    /// Start the countdown, triggering the listeners after 'seconds' have passed.
    /// </summary>
    public void Begin()
    {
        //Set the start time to now
        timeStart = Time.time;

        //Flag that we've begun counting down
        started = true;
    }

    void Invoke()
    {
        //Trigger the associated events
        action.Invoke();

        //Unflag
        started = false;

        //If we're supposed to loop automatically,
        if (looping)
        {
            //Start again
            Begin();
        }
    }

    /// <summary>
    /// Adjust 'seconds' by the given amount, never going below 'minimum'
    /// </summary>
    /// <param name="amount"></param>
    public void Adjust(float amount)
    {
        //Change seconds relative to the given amount, never lower than the minimum, as big as you want 
        seconds = Mathf.Clamp(seconds + amount, minimum, float.PositiveInfinity);
    }
}
