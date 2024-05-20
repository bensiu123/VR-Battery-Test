using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidanceController : MonoBehaviour
{
    public GameObject CameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRotation();
    }

    void UpdateRotation()
    {
        /** TODO to be done*/

        var playerTransform = CameraOffset.GetComponent<Transform>();
        var guidanceTransform = this.GetComponent<Transform>();

        var playerPosition = playerTransform.position;
        var guidancePosition = guidanceTransform.position;

        Debug.Log($"player: {playerPosition.x}, {playerPosition.y}, {playerPosition.z}");
        Debug.Log($"guidance: {guidancePosition.x}, {guidancePosition.y}, {guidancePosition.z}");

        var direction = guidanceTransform.position - playerTransform.position;
        direction.y = 0f;

        Debug.Log($"direction: {direction.x}, {direction.y}, {direction.z}");
        guidanceTransform.rotation = Quaternion.Euler(direction);
    }
}
