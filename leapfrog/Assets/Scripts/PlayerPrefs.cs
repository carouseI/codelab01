using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefs : MonoBehaviour
{
    const string SOUND_VOL_KEY = "soundVolKey"; //const = no change needed

    private int soundVolume; //int holds sound volume

    //property for sound volume setting
    //property structure = secure + allows mult lines to be executed when setting variable

    public int SoundVolume
    {
        get
        {
            //read sound from playerprefs
            soundVolume = PlayerPrefs.GetInt(SOUND_VOL_KEY, 20); //set playerpref to 20
            return soundVolume; //return variable
        }
        set
        {
            soundVolume = value; //set variable to whatever value is
            PlayerPrefs.SetInt(SOUND_VOL_KEY, soundVolume); //new value
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("blank", 2); //blank = 2
        Debug.Log(PlayerPrefs.GetInt("blank", 5)); //read playerpref

        Debug.Log(PlayerPrefs.GetInt("anotherKey")); //read playerpref anotherKey

        SoundVolume = 3; //use SoundVolume property, set volume to 3
        SoundVolume = PlayerPrefs.GetInt(SOUND_VOL_KEY, 20); //or, set SV property using playerprefs
    }
}
