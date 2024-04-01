using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class VFXController : MonoBehaviour
{

    public int pick = 0;
    public int selectedColor = 0;
    public int amplitude = 1;
    public ClickPosition clickPosition;
    public Camera cam;
    public Color objectColor;

    public List<Color> colors = new List<Color>();

    [Header("Sound")]
    [SerializeField]public bool pentatonic = false;
    public float[] location = new float[8];
    public float bottomBuffer;
    public float topBuffer;
    public GameObject dividerLines;

    [Header("UI and Settings")]
    public GameObject ui;
    private bool isUIOn;
    public Slider colorSlider;
    public Slider intensitySlider;
    public Toggle backgroundToggle;
    private bool isBackgroundOn = true;
    public Toggle musicModeToggle;
    public Toggle guidelineToggle;

    [Header("Background")]
    public ParticleSystem backgroundParticles;
    public Material backgroundColor;

    public GameObject[] dividers = new GameObject[8]; //Needs to be same length as location array

    // Start is called before the first frame update
    void Start()
    {
        for (int y = 0; y < location.Length; y++)
        {
            dividers[y] = Instantiate(dividerLines, new Vector3(0f, -9f, 0), transform.rotation);
        }
        Color();
        ToggleScale();
        ToggleGuideLines();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            ToggleUI();
            
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

    private void MusicScale()
    {
        if(pentatonic)
        {
            for(int i = 0; i < 6; i++)
            { 
                if(i == 0)
                {
                    location[i] = bottomBuffer;
                }
                float newLocation = Mathf.Lerp(-5 + bottomBuffer, 5 - topBuffer, cam.ScreenToViewportPoint(new Vector2(0f, Screen.height / 5 * i)).y);
                location[i] = newLocation;
                float yValue = location[i];
                dividers[i].transform.position = new Vector3(0f, -9f, yValue);
            }
        } else
        {
            for(int i = 0; i < location.Length; i++)
            {
                if (i == 0)
                {
                    location[i] = bottomBuffer;
                }
                float newLocation = Mathf.Lerp(-5 + bottomBuffer, 5 - topBuffer, cam.ScreenToViewportPoint(new Vector2(0f, Screen.height / 7 * i)).y);
                location[i] = newLocation;
                float yValue = location[i];
                dividers[i].transform.position = new Vector3(0f, -9f, yValue);
            }
        }
    }

    public void ToggleBackground()
    {
        if(isBackgroundOn)
        {
            backgroundParticles.Stop();
        } else
        {
            backgroundParticles.Play();
        }
        isBackgroundOn = !isBackgroundOn;
    }

    public void ToggleScale()
    {
        pentatonic = musicModeToggle.isOn;
        MusicScale();
        if(pentatonic)
        {
            for(int k = 6; k < dividers.Length; k++)
            {
                dividers[k].transform.position = new Vector3(0f, -15f, 0f);
            }
        }
    }

    public void ToggleGuideLines()
    {
        for(int u = 0; u < dividers.Length; u++)
        {
            dividers[u].SetActive(guidelineToggle.isOn);
        }
    }

    private void ToggleUI()
    {
        isUIOn = !isUIOn;
        ui.SetActive(isUIOn);
        Cursor.visible = isUIOn;
    }
}
