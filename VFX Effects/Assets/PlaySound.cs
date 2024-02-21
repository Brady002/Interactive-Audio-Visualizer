using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

    public AudioSource sound;

    private void OnEnable()
    {
        float location = transform.position.z;
        if(location > 0 && location <= 1)
        {
            sound.pitch = 1f; //C
        } else if (location > 1 &&  location <= 2)
        {
            sound.pitch = 1.12f; //D3
        } else if (location > 2 && location <= 3)
        {
            sound.pitch = 1.26f; //E3
        } else if(location > 3 && location <= 4)
        {
            sound.pitch = 1.33f; //F3
        } else if(location > 4)
        {
            sound.pitch = 1.5f; //G3
        }

        if(location <= 0 && location >= -1)
        {
            sound.pitch = .94f; //B3
        } else if(location < -1 && location >= -2)
        {
            sound.pitch = .84f; //A3
        } else if(location > -2 && location <= -3)
        {
            sound.pitch = .74f; //G2
        } else if(location < -3)
        {
            sound.pitch = .66f; //F2
        }
        sound.Play();
    }
}
