using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float amplitude = 0.5f;
    public float frequency = 1f;

    private Vector3 startPos;
    private bool isBouncing = true;
    

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (isBouncing)
        {
            Vector3 tempPos = startPos;
            tempPos.y += Mathf.Sin(Time.time * Mathf.PI * frequency) * amplitude;
            transform.position = tempPos;
        }
    }

    public void StopBouncing()
    {
        isBouncing = false;
        transform.position = startPos;  // Reset to original position
    }
    

}

