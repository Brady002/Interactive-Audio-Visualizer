using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXController : MonoBehaviour
{

    public int pick = 0;
    public int selectedColor = 0;
    public int amplitude = 1;
    public ClickPosition clickPosition;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Screen.width);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            Application.Quit();
        }
        if(Input.GetKeyUp(KeyCode.D) && pick < clickPosition.frontFaceEffects.Count - 1) 
        {
            pick++;
        }
        if(Input.GetKeyUp(KeyCode.A) && pick > 0)
        {
            pick--;
        }

        //Set Color

        if (Input.GetKeyUp(KeyCode.W))
        {
            selectedColor++;
            clickPosition.SetColor(amplitude);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            selectedColor--;
            clickPosition.SetColor(amplitude);
        }

        if(Input.GetKeyUp(KeyCode.UpArrow) && amplitude < 15)
        {
            amplitude++;
            clickPosition.SetColor(amplitude);
        }
        if(Input.GetKeyUp(KeyCode.DownArrow) && amplitude > 1)
        {
            amplitude--;
            clickPosition.SetColor(amplitude);
        }

    }
}
