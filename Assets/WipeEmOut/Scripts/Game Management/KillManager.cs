using TMPro;
using UnityEngine;

public class KillManager : MonoBehaviour
{
    //Reference to the TMP Text
    [Header("References")]
    [SerializeField] TMP_Text killText;

    //Current zombies you have killed
    [Header("Killed Enemis")]
    [SerializeField] private int killCount;

    //On start reset kills to 0

    private void Start()
    {
        killCount = 0;
        killText.text = "Kills: " + killCount.ToString();
    }

    //Condition to run whenever you kill a enemy

    public void AddKillCount(int value) 
    {
        //Add a counter to the current enemies you killed
        killCount += value;

        //Update the text to match the counter
        killText.text = "Kills: " + killCount.ToString();
    }
}
