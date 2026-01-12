using System.Collections;
using UnityEngine;

public class ChestOpening : MonoBehaviour
{
    public GameObject chestLid;      
    public GameObject lock1;         // Lock to disable
    private bool hasOpened = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key") && !hasOpened)
        {
            hasOpened = true;
            lock1.SetActive(false);
            chestLid.SetActive(false);
        }
    }

}
