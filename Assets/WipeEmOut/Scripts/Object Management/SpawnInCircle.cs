using UnityEngine;

public class SpawnInCircle : MonoBehaviour
{
    [Tooltip("The game object to spawn")]
    public GameObject prefab;
    [Tooltip("The radius from centre to spawn from")]
    public float radius = 12f;

    void Start()
    {
        //Spawn an enemy at the start
        Spawn();
    }

    public void Spawn()
    {
        //If there's no prefab assigned in the inspector, do nothing
        if (prefab == null)
        return;

        //Get a random point on a circumference of a cicle
        Vector3 point = Random.insideUnitCircle.normalized * radius;

        //Instantiate the prefab at the random point with no rotation
        Instantiate(prefab, point, Quaternion.identity);
    }
}
