using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ClickPosition : MonoBehaviour
{
    public Camera cam;
    public VFXController controller;
    public GameObject effect;
    public GameObject effect2;
    public List<GameObject> effects = new List<GameObject>();
    public int numOfPanels = 7;

    [Header("Colors")]
    public Color orange;
    public Color purple;
    public Color pink;


    private Color matColor;

    private void Start()
    {
        SetColor();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Material colorMaterial;
            GameObject effectGO;

            Physics.Raycast(ray, out hit);

            if(hit.collider != null)
            {
                
                Vector3 spawnPoint = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                effectGO = Instantiate(effects[controller.pick], spawnPoint, hit.transform.rotation);
                if(controller.selectedColor < 7)
                {
                    SetColor();
                }
                if(controller.selectedColor == 7)
                {
                    DynamicColorPicker();
                }
                colorMaterial = effectGO.GetComponentInChildren<Renderer>().material;
                colorMaterial.SetColor("_Color", matColor);
                
            }
        }
    }

    public void SetColor()
    {
        matColor = controller.objectColor * controller.amplitude;
    }

    public void DynamicColorPicker()
    {
        int _amplitude = controller.amplitude;
        float location = Mathf.Lerp(0f, Screen.width, cam.ScreenToViewportPoint(Input.mousePosition).x);
        Debug.Log(cam.ScreenToViewportPoint(Input.mousePosition).x);
        if (location < Screen.width / numOfPanels)
        {
            matColor = Color.red * _amplitude;
        }
        else if (location >= Screen.width / numOfPanels && location < Screen.width / numOfPanels * 2)
        {
            matColor = orange * _amplitude;
        }
        else if (location >= Screen.width / numOfPanels * 2 && location < Screen.width / numOfPanels * 3)
        {
            matColor = Color.yellow * _amplitude;
            Debug.Log("3");
        }
        else if (location >= Screen.width * 3 / numOfPanels && location < Screen.width / numOfPanels * 4)
        {
            matColor = Color.green * _amplitude;
            Debug.Log("4");
        }
        else if (location >= Screen.width * 4 / numOfPanels && location < Screen.width / numOfPanels * 5)
        {
            matColor = Color.blue * _amplitude;
            
            Debug.Log("5");
        }
        else if (location >= Screen.width * 5 / numOfPanels && location < Screen.width / numOfPanels * 6)
        {
            matColor = purple * _amplitude;
            Debug.Log("6");
        } else
        {
            matColor = pink * _amplitude;
            Debug.Log("7");
        }
    }
    
}
