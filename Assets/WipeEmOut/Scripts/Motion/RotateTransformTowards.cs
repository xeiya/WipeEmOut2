using UnityEngine;

public class RotateTransformTowards : MonoBehaviour
{
    [Tooltip("What transform to turn towards")]
    public Transform target;
    [Tooltip("How many 360 rotations this can complete each second")]
    public float speed;
    
    void Start()
    {
        //If there's no target set from the inspector...
        if (!target)
        {
            //Try to get a default target
            target = DefaultTarget.Target.transform;
        }
    }

    void Update()
    {
        //If we have no target, do nothing
        if (!target)
            return;

        //Get the desired direction
        Vector3 directionDesired = target.position - transform.position;
        //Store the current 2D rotation
        float currentAngle = transform.localEulerAngles.z;
        //Snap the transform to the desired direction
        transform.right = directionDesired;
        //Get a new angle which steps towards the desired direction by the given speed
        float newAngle = Mathf.MoveTowardsAngle(currentAngle, transform.localEulerAngles.z, 360 * speed * Time.deltaTime);
        //Re-set our rotation using the calculated angle
        transform.localEulerAngles = new Vector3(0, 0, newAngle);
    }
}
