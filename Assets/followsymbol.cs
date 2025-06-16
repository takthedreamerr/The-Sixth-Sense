using UnityEngine;

public class FingerFollowAndBounceUI : MonoBehaviour
{
    [Header("Symbol world object to follow")]
    public Transform target;

    [Header("Bouncing animation")]
    public float amplitude = 10f;  // How far it moves (pixels)
    public float frequency = 1f;   // How fast it moves

    [Header("Offset from symbol in screen pixels")]
    public Vector2 baseScreenOffset;

    private Camera mainCamera;
    private RectTransform rectTransform;
    private Vector3 baseScreenPos;

    void Start()
    {
        mainCamera = Camera.main;
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (target == null || rectTransform == null || mainCamera == null)
            return;

        // Get screen position of the world object
        Vector3 screenPos = mainCamera.WorldToScreenPoint(target.position);
        baseScreenPos = screenPos + (Vector3)baseScreenOffset;

        // Apply bounce
        float bounce = Mathf.Sin(Time.time * Mathf.PI * frequency) * amplitude;
        Vector3 bounceOffset = new Vector3(0, bounce, 0);

        // Final screen position with bounce
        rectTransform.position = baseScreenPos + bounceOffset;
    }

    public void HideFinger()
    {
        gameObject.SetActive(false);
    }
}
