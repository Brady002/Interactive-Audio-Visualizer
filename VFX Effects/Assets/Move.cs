using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    private Rigidbody rb;
    [SerializeField]
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.up * speed;
    }

    private void OnEnable()
    {
        StartCoroutine(Kill());
    }

    private IEnumerator Kill()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
        Destroy(this.gameObject.GetComponentInChildren<Renderer>().material);
    }
}
