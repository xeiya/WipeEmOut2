using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    //This will hold a reference to the main camera
    new Camera camera;
    
    void Start()
    {
        //Cache the main camera so we don't have to check Camera.main every frame (expensive!)
        camera = Camera.main;
    }

    
    void Update()
    {
        //Get the world position based on the mouse's position on the screen
        Vector3 worldPosition = camera.ScreenPointToRay(Input.mousePosition).origin;
        //Flatten the z position
        worldPosition.z = 0;
        //Update this object's position using the world position calculated
        transform.position = worldPosition;
    }
}
