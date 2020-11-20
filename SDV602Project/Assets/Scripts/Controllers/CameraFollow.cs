using UnityEngine;

//used for the minigame
public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.1f;
    public Vector3 offset;

    //Used for getting the camera to follow the sphere in the minigame
    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
