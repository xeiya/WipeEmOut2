using UnityEngine;

public class MoveWithInput : MonoBehaviour
{
    [Tooltip("How many units to move per second")]
    public float speed = 1f;

    void Update()
    {
        //Get the input from the keys
        Vector2 input = GetInput();

        //Move based on the input provided
        transform.position += (Vector3)input * speed * Time.deltaTime;
    }

    private Vector2 GetInput()
    {
        //Return a vector where x = the 'Horizontal' axis and y = the 'Vertical' axis from the Input Manager.
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
