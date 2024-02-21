using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchPosition : MonoBehaviour
{

    public GameObject effect;
    public GameObject effect2;
    private int pick = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Instantiate(effect, touch.position, Quaternion.Euler(0f, 0f, 0f));
                    break;
            }
        }
    }
}
