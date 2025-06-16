using UnityEngine;

public class clickmovement : MonoBehaviour 
{
    public float amplitude = 10f;  // How far it moves (pixels)
    public float frequency = 1f;   // How fast it moves

    private Vector3 startPos;
    public GameObject fingerClicker;

    void OnEnable()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        Vector3 tempPos = startPos;
        tempPos.y += Mathf.Sin(Time.time * Mathf.PI * frequency) * amplitude;
        transform.localPosition = tempPos;
    }

    void Start()
    {
        if (fingerClicker != null)
            fingerClicker.SetActive(true);  

        // 
    }
}
