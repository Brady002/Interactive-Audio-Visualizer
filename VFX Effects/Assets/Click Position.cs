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
    public List<GameObject> frontFaceEffects = new List<GameObject>();
    public int numOfPanels = 7;

    [Header("Colors")]
    public Color orange;
    public Color purple;
    public Color pink;


    private Color matColor;

    private void Start()
    {
        SetColor(1);
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
                effectGO = Instantiate(frontFaceEffects[controller.pick], spawnPoint, hit.transform.rotation);
                if(controller.selectedColor == 8)
                {
                    DynamicColorPicker();
                }
                if(controller.selectedColor == 9)
                {
                    Color color1 = new Vector4(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f));
                    Color color2 = new Vector4(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f));
                    float time = 0;
                    while(time <= 1f)
                    {
                        matColor = new Vector4(Mathf.Lerp(color1.r, color2.r, time), Mathf.Lerp(color1.g, color2.g, time), Mathf.Lerp(color1.b, color2.b, time));
                        time += Time.deltaTime;
                    }
                }
                colorMaterial = effectGO.GetComponentInChildren<Renderer>().material;
                colorMaterial.SetColor("_Color", matColor);
                
            }
        }
    }

    public void SetColor(int _amplitude)
    {
        switch(controller.selectedColor)
        {
            case 0:
                matColor = Color.white * _amplitude;
                break;
            case 1:
                matColor = Color.red * _amplitude;
                break;
            case 2:
                matColor = Color.green * _amplitude;
                break;
            case 3:
                matColor = Color.blue * _amplitude;
                break;
            case 4:
                matColor = Color.yellow * _amplitude;
                break;
            case 5:
                matColor = Color.magenta * _amplitude;
                break;
            case 6:
                matColor = Color.cyan * _amplitude;
                break;
            case 7:
                matColor = new Vector4(255, 200, 0)/255 * _amplitude;
                break;
            case 8:
                DynamicColorPicker();
                break;
            case 9:
                break;
            default:
                controller.selectedColor = 0;
                break;
        }
    }

    private void DynamicColorPicker()
    {
        int _amplitude = controller.amplitude;
        float location = Mathf.Lerp(0f, Screen.width, cam.ScreenToViewportPoint(Input.mousePosition).x);
        Debug.Log(cam.ScreenToViewportPoint(Input.mousePosition).x);
        if (location < Screen.width / numOfPanels)
        {
            matColor = Color.red * _amplitude;
            Debug.Log("1");
        }
        else if (location >= Screen.width / numOfPanels && location < Screen.width / numOfPanels * 2)
        {
            matColor = orange * _amplitude;
            Debug.Log("2");
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
