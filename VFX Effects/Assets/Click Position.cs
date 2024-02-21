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
                colorMaterial = effectGO.GetComponentInChildren<Renderer>().material;
                colorMaterial.SetColor("_Color", matColor);
                /*switch (controller.pick)
                {
                    case 0:
                        
                        effectGO = Instantiate(effect, spawnPoint, hit.transform.rotation);
                        colorMaterial = effectGO.GetComponentInChildren<Renderer>().material;
                        colorMaterial.SetColor("_Color", matColor);
                        break;
                    case 1:
                        spawnPoint = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                        effectGO = Instantiate(effect2, spawnPoint, hit.transform.rotation);
                        colorMaterial = effectGO.GetComponentInChildren<Renderer>().material;
                        colorMaterial.SetColor("_Color", matColor);
                        break;
                    default:
                        controller.pick = 0;
                        break;
                }*/
                
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
            default:
                controller.selectedColor = 0;
                break;
        }
    }

    
}
