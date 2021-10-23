using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject_Chase : MonoBehaviour
{

    public float smoothness;
    public Transform targetObject;
    private Vector3 initialOffset;
    private Vector3 cameraPosition;

    public enum RelativePosition { InitialPosition, Position1, Position2}
    public RelativePosition relativePosition;
    public Vector3 position1;
    public Vector3 position2;


    // Start is called before the first frame update
    void Start()
    {
        relativePosition = RelativePosition.InitialPosition;
        initialOffset = transform.position - targetObject.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cameraPosition = targetObject.position + CameraOffset(relativePosition);
        transform.position = Vector3.Lerp(transform.position, cameraPosition, smoothness * Time.fixedDeltaTime);
    }

    Vector3 CameraOffset(RelativePosition relativePos)
    {
        
            Vector3 currentOffset;
            switch (relativePos)
            {
                case RelativePosition.Position1:
                    currentOffset = position1;
                    break;
                case RelativePosition.Position2:
                    currentOffset = position2;
                    break;
                default:
                    currentOffset = initialOffset;
                    break;
            }
            return currentOffset;

    }
}
