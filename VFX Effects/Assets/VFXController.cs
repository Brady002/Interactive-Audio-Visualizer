using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VFXController : MonoBehaviour
{

    public int pick = 0;
    public int selectedColor = 0;
    public int amplitude = 1;
    public ClickPosition clickPosition;
    
    public Color objectColor;

    public List<Color> colors = new List<Color>();

    [Header("UI and Settings")]
    public GameObject ui;
    private bool isUIOn;
    public Slider colorSlider;
    public Slider intensitySlider;
    public Toggle backgroundToggle;

    [Header("Background")]
    public ParticleSystem backgroundParticles;
    public Material backgroundColor;

    // Start is called before the first frame update
    void Start()
    {
        Color();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            isUIOn = !isUIOn;
            ui.SetActive(isUIOn);
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            Application.Quit();
        }
        if(Input.GetKeyUp(KeyCode.D) && pick < clickPosition.effects.Count - 1) 
        {
            pick++;
            ChangeBackgroundEffect();
        }
        if(Input.GetKeyUp(KeyCode.A) && pick > 0)
        {
            pick--;
            ChangeBackgroundEffect();
        }

        //Set Color

        if (Input.GetKeyUp(KeyCode.W))
        {
            if(selectedColor < colors.Count + 1)
            {
                selectedColor++;
            } else
            {
                selectedColor = 0;
            }
            
            colorSlider.value = (int)selectedColor;
            Color();
            SelectNewColor();
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            if (selectedColor >= 0)
            {
                selectedColor--;
            }
            else
            {
                selectedColor = colors.Count;
            }

            Color();
            colorSlider.value = (int)selectedColor;
            SelectNewColor();
        }

        if(Input.GetKeyUp(KeyCode.UpArrow) && amplitude < 15)
        {
            amplitude++;
            intensitySlider.value = amplitude;
            SelectNewColor();
        }
        if(Input.GetKeyUp(KeyCode.DownArrow) && amplitude > 1)
        {
            amplitude--;
            intensitySlider.value = amplitude;
            SelectNewColor();
        }

    }

    public void SelectNewColor()
    {
        selectedColor = (int)colorSlider.value;
        amplitude = (int)intensitySlider.value;
        Color();
        backgroundColor.color = objectColor;
        clickPosition.SetColor();
    }

    public void Color()
    {
        objectColor = colors[selectedColor] * amplitude;
        
    }

    private void ChangeBackgroundEffect()
    {
        Debug.Log(clickPosition.effects[pick].GetComponent<ShapeBehavior>().shape);
        backgroundParticles.GetComponent<ParticleSystemRenderer>().mesh = clickPosition.effects[pick].GetComponent<ShapeBehavior>().shape;
    }
}
