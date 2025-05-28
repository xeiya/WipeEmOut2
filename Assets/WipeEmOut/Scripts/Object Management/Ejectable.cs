using UnityEngine;

public class Ejectable : MonoBehaviour
{
    /// <summary>
    /// Whether to eject a single parent up the hierarchy, or unparent completely to the root of the scene
    /// </summary>
    public enum Mode
    {
        Partial,
        Total
    }

    /// <summary>
    /// Eject this transform using the given mode.
    /// </summary>
    /// <param name="mode"></param>
    public void Eject(Mode mode)
    {
        if (mode == Mode.Partial)
            EjectPartial();
        else
            EjectTotal();
    }

    /// <summary>
    /// Eject this transform one parent upwards in the hierarchy.
    /// </summary>
    public void EjectPartial()
    {
        transform.parent = transform.parent.parent ? transform.parent.parent : null;
    }

    /// <summary>
    /// Eject this transform into the root of the scene.
    /// </summary>
    public void EjectTotal()
    {
        transform.parent = null;
    }
}
