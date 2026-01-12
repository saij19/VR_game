using UnityEngine;

public class RespawnableObject : MonoBehaviour
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Vector3 originalScale;

    private void Awake()
    {
        // store original transform values at startup
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        originalScale = transform.localScale;
    }

    public void Respawn()
    {
       // teleport back
        transform.position = originalPosition;
        transform.rotation = originalRotation;
        transform.localScale = originalScale;
    }
}
