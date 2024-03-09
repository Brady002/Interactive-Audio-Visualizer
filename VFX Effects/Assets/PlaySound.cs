using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

    public AudioSource sound;
    private VFXController controller;
    public float[] scale = new float[8] {.66f, .74f, .84f, .94f, 1f, 1.12f, 1.26f, 1.33f };
    public float[] pentatonicScale = new float[5] { .84f, 1f, 1.12f, 1.26f, 1.5f};
 
    private void OnEnable()
    {
        //float location = transform.position.z;
        controller = GameObject.Find("Controller").GetComponent<VFXController>();
        SetPitch();
        /*if(location > 0 && location <= 1)
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
        }*/
        
    }

    private void SetPitch()
    {
        float location = transform.position.z;
        
        if(controller.pentatonic)
        {
            for(int i = 0; i < 6; i++)
            {
                if(location > controller.location[i] && location <= controller.location[i + 1])
                {
                    sound.pitch = pentatonicScale[i];
                }
            }
        } else
        {
            for (int i = 0; i < controller.location.Length; i++)
            {
                if (location > controller.location[i] && location <= controller.location[i + 1])
                {
                    sound.pitch = scale[i];
                }
            }
        }
        sound.Play();
    }
}
