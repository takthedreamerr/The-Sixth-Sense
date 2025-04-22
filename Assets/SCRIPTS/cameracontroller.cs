using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    Transform target;
    Vector3 velocity = Vector3.zero;

    [Range(0, 1)]
    public float smoothTime;
    public Vector3 postionOffest;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        Vector3 targetPostion = target.position + postionOffest;
        transform.position = Vector3.SmoothDamp(transform.position,targetPostion,ref velocity, smoothTime);
    }
}    
