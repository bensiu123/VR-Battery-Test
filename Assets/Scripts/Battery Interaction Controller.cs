using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BatteryInteractionController : MonoBehaviour
{
    public GameObject ChamberPlatform;
    public Material GrabbedMaterial;
    public Material SuccessMaterial;
    public double MinYPosition = 0.5;

    private Material DefaultMaterial;
    private Vector3 InitialPosition;
    private Quaternion InitialRotation;
    private Rigidbody Rigidbody;
    private Renderer Renderer;
    private bool IsGrabbing = false;
    private bool IsOnPlatform = false;

    private void Start()
    {
        InitialPosition = transform.position;
        InitialRotation = transform.rotation;
        Rigidbody = GetComponent<Rigidbody>();
        Renderer = GetComponent<Renderer>();
        DefaultMaterial = Renderer.material;
        if (GrabbedMaterial == null) GrabbedMaterial = DefaultMaterial;
        if (SuccessMaterial == null) SuccessMaterial = DefaultMaterial;
    }

    private void Update()
    {
        ResetPositionIfLost();
        SetMaterial();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.Equals(ChamberPlatform))
        {
            IsOnPlatform = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.Equals(ChamberPlatform))
        {
            IsOnPlatform = false;
        }
    }

    public void OnGrabSelectEnter(SelectEnterEventArgs _)
    {
        IsGrabbing = true;
    }

    public void OnGrabSelectExit(SelectExitEventArgs _)
    {
        IsGrabbing = false;
    }

    private void ResetPositionIfLost()
    {
        if (IsGrabbing) return;
        if (transform.position.y < MinYPosition)
        {
            transform.position = InitialPosition;
            transform.rotation = InitialRotation;

            Rigidbody.velocity = Vector3.zero;
            Rigidbody.angularVelocity = Vector3.zero;
        }

    }

    private void SetMaterial()
    {
        if (IsOnPlatform)
        {
            Renderer.material = SuccessMaterial;
        }
        else if (IsGrabbing)
        {
            Renderer.material = GrabbedMaterial;
        }
        else
        {
            Renderer.material = DefaultMaterial;
        }
    }

}
