using UnityEngine;

public class FindGameManager : MonoBehaviour
{
    [SerializeField] private KillManager kills;

    //Automatically finds the kill manager
    private void Start()
    {
        kills = FindAnyObjectByType<KillManager>();
    }

    //Adds kill count
    public void AddZombieKill(int value)
    {
        kills.AddKillCount(value);
    }
}