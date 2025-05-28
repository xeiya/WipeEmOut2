using UnityEngine;

public class MoveTransformTowards : MonoBehaviour
{
    [Tooltip("What transform to move towards")]
    public Transform target;
    [Tooltip("How many units to move per second")]
    public float speed;
    
    void Start()
    {
        //If no target has been set...
        if (!target)
        {
            //Try to get a default target
            target = DefaultTarget.Target.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If we have no target, do nothing
        if (!target)
        return;

        //Move towards the target using speed
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
