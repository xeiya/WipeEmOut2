using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private string channelName;

    private void Start()
    {
        //Checks if the have a "channelName" file
        if (PlayerPrefs.HasKey(channelName)) 
        {
            //Sets the volume and saves the value to the files
            AudioManager.SetVolume(channelName, PlayerPrefs.GetFloat(channelName));

            //Set the slider to match the current value
            GetComponent<Slider>().value = PlayerPrefs.GetFloat(channelName);
        }
    }


    //Sets the volume of the game
    public void SetVolume(float volume) 
    {
        AudioManager.SetVolume(channelName, volume);

        PlayerPrefs.SetFloat(channelName, volume);

        PlayerPrefs.Save();
    }
}
