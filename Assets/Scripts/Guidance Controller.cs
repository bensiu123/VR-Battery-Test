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
        var guidanceTransform = this.GetComponent<RectTransform>();

        var playerPosition = playerTransform.position;
        var guidancePosition = guidanceTransform.position;

        var lookAt = new Vector3(playerPosition.x, guidancePosition.y, playerPosition.z);

        guidanceTransform.LookAt(lookAt);
    }
}
