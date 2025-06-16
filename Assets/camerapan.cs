using UnityEngine;

public class CameraPan : MonoBehaviour
{
    public Transform target;     
    public float panSpeed = 2f;
    public bool isPanning = false;  

    private Vector3 originalPosition;
    private Transform originalParent;

    void Start()
    {
        GetComponent<CameraPan>().StartPan();
    }



    public void StartPan()
    {
        originalParent = transform.parent;
        transform.parent = null;  // Unparent
        originalPosition = transform.position;
        isPanning = true;
    }

    void Update()
    {
        if (isPanning)
        {
            Vector3 targetPos = new Vector3(target.position.x, target.position.y, originalPosition.z);
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * panSpeed);

            if (Vector3.Distance(transform.position, targetPos) < 0.1f)
            {
                isPanning = false;
                transform.parent = originalParent;  // Re-parent
            }
        }
    }
}
