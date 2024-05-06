using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamberPlatformController : MonoBehaviour
{
    public GameObject battery;
    public Material SuccessMaterial;

    private Renderer Renderer;
    private Material DefaultMaterial;

    // Start is called before the first frame update
    void Start()
    {
        Renderer = GetComponent<Renderer>();
        DefaultMaterial = Renderer.material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.Equals(battery))
        {
            GetComponent<Renderer>().material = SuccessMaterial;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.Equals(battery))
        {
            GetComponent<Renderer>().material = DefaultMaterial;
        }
    }

}
