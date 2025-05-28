using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    /// <summary>
    /// Destroy this game object.
    /// </summary>
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
