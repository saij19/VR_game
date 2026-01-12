using UnityEngine;

public class BookVisualSwitcher : MonoBehaviour
{
    public GameObject closedMesh;
    public GameObject openMesh;

    void Start()
    {
        // ensure it starts closed
        SetOpen(false);
    }

    public void SetOpen(bool isOpen)
    {
        closedMesh.SetActive(!isOpen);
        openMesh.SetActive(isOpen);
        Debug.Log($"{gameObject.name} is now " + (isOpen ? "OPEN" : "CLOSED"));
    }
}
