using System.Collections;
using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    public GameObject door;      
    public GameObject lock2;        
    public AudioClip openSound;      


    private bool isOpen = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key2") && !isOpen)
        {
            isOpen = true;
            door.SetActive(false);

        }
    }

 
}




