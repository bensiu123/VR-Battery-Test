using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorHinge
{
    Left,
    Right,
}

public class ChamberDoorController : MonoBehaviour
{
    public Material OpenedMaterial;

    private HingeJoint joint;
    private Renderer Renderer;
    private Material DefaultMaterial;
    private Quaternion InitialRotation;

    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<HingeJoint>();
        Renderer = GetComponent<Renderer>();
        DefaultMaterial = Renderer.material;
        InitialRotation = transform.rotation;

        if (OpenedMaterial == null) OpenedMaterial = DefaultMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        var angle = joint.angle;
        if (angle < 1)
        {
            transform.rotation = InitialRotation;
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            Renderer.material = DefaultMaterial;
        }
        else
        {
            Renderer.material = OpenedMaterial;
        }
    }
}
