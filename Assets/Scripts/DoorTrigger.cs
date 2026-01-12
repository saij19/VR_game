using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour
{
    public float openAngle = -90f;
    public float closedAngle = 0f;
    public float openSpeed = 1f;
    public float closeDelay = 3f; // Delay in seconds before closing

    private bool isOpen = false;
    private Coroutine closeDoorCoroutine;

    private Quaternion openRotation;
    private Quaternion closedRotation;

    void Start()
    {
        openRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, openAngle, 0));
        closedRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, closedAngle, 0));
    }

    void Update()
    {
        if (isOpen)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, openRotation, Time.deltaTime * openSpeed);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, closedRotation, Time.deltaTime * openSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOpen = true;
            if (closeDoorCoroutine != null)
            {
                StopCoroutine(closeDoorCoroutine);
                closeDoorCoroutine = null;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            closeDoorCoroutine = StartCoroutine(CloseDoorAfterDelay());
        }
    }

    private IEnumerator CloseDoorAfterDelay()
    {
        yield return new WaitForSeconds(closeDelay);
        isOpen = false;
    }
}

