using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            Shift();
        }
    }

    private void Shift()
    {
        Material newMaterial = GetComponent<Renderer>().material;
        newMaterial.SetColor("_Color", Color.red);
    }
}
